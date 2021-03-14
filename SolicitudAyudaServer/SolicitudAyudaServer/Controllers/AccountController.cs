using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SolicitudAyuda.Model;
using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Entities;
using SolicitudAyuda.Model.Helpers;
using SolicitudAyuda.Model.Services;
using SolicitudAyuda.Model.Services.Signatures;

namespace SolicitudAyudaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : AppBaseController
    {
        private IConfiguration _config;
        private DataContext db;
        private readonly ISendEmailService mailService;
        private readonly IWebHostEnvironment environment;
        private readonly IUsuariosService usuariosService;

        public AccountController(IConfiguration receivedConfig,
            DataContext db, 
            ISendEmailService mailService, 
            IWebHostEnvironment environment,
            IUsuariosService usuariosService) : base(db)
        {
            this._config = receivedConfig;
            this.db = db;
            this.mailService = mailService;
            this.environment = environment;
            this.usuariosService = usuariosService;
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult login([FromBody] LoginModel loginModel)
        {
            var md5Password = MD5Helper.MD5Hash(loginModel.Password);

            var usuario = db.Usuarios.SingleOrDefault(u => (u.Login == loginModel.Login || u.Email == loginModel.Login) && u.Password == md5Password);

            if (usuario != null)
            {
                var tokenString = GenerateJSONWebToken(usuario);

                return Ok(new
                {
                    token = tokenString,
                    Usuario = new
                    {
                        email = usuario.Email,
                        nombreCompleto = usuario.NombreCompleto
                    }
                });
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GenerateJSONWebToken(Usuario usuario)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim("UsuarioId", usuario.Id.ToString()));

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(120),
              signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [Authorize]
        [Route("heartbeat")]
        public IActionResult heartbeat()
        {
            var result = new
            {
                alive = "Ok"
            };

            return new JsonResult(result);
        }

        [HttpGet]
        [Authorize]
        [Route("GetPuedeGestionarTipoSolicitud")]
        public IActionResult GetPuedeGestionar(int tipoSolicitudId)
        {
            var usuarioId = int.Parse(User.Claims.Where(c => c.Type == "UsuarioId").FirstOrDefault().Value);

            var comisionesUsuario = db.UsuarioComisionAprobacion
                .Include(uca => uca.ComisionAprobacion)
                .ThenInclude(sc => sc.TiposSolicitudes)
                .Where(uca => uca.UsuarioId == usuarioId)
                .SelectMany(uca => uca.ComisionAprobacion.TiposSolicitudes);

            var gestiona = comisionesUsuario.Any(t => t.Id == tipoSolicitudId);

            return new JsonResult(new { puedeGestionar = gestiona });
        }

        [HttpPost]
        [Authorize]
        [Route("CrearUsuario")]
        public IActionResult CrearUsuario(CreacionUsuarioDTO usuarioDTO)
        {
            HttpDataResponse response = new HttpDataResponse();

            var usuarioConEmail = db.Usuarios.FirstOrDefault(u => u.Email == usuarioDTO.Email && u.Disponible && (usuarioDTO.Id == 0));

            if (usuarioConEmail != null)
            {
                response.AddError($"Ya existe un usuario con el email {usuarioDTO.Email} que pertenece a {usuarioConEmail.NombreCompleto}");
                return new JsonResult(response); 
            }

            var usr = CurrentUsuario;

            if (usr != null)
            {
                db.Entry(usr).Collection(u => u.PermisosUsuario).Load();

                if (usr.PermisosUsuario.Any(u => u.PermisoId == 8 && u.Disponible))
                {
                    using (TransactionScope scope = new TransactionScope())
                    {
                        Usuario usuario = null;
                        Maestro maestro = null;

                        if (usuarioDTO.Id > 0)
                        {
                            usuario = db.Usuarios.Single(u => u.Id == usuarioDTO.Id);
                            var mId = usuario.MaestroId ?? 0;
                            maestro = db.Maestros.SingleOrDefault(m => m.Id == mId);
                        }
                        else
                        {
                            maestro = new Maestro();
                            usuario = new Usuario();
                        }

                        if (maestro == null)
                        {
                            maestro = new Maestro();
                            db.Maestros.Add(maestro);
                        }

                        maestro.Cedula = usuarioDTO.Cedula;
                        maestro.NombreCompleto = usuarioDTO.NombreCompleto;
                        maestro.Cargo = usuarioDTO.Cargo;
                        maestro.SeccionalId = usuarioDTO.SeccionalId;
                        maestro.Sexo = usuarioDTO.Sexo;
                        maestro.FechaNacimiento = usuarioDTO.FechaNacimiento;
                        maestro.Direccion = usuarioDTO.Direccion;
                        maestro.TelefonoCelular = usuarioDTO.TelefonoCelular;
                        maestro.TelefonoLabora = usuarioDTO.TelefonoLabora;
                        maestro.TelefonoResidencial = usuarioDTO.TelefonoResidencial;

                        db.SaveChanges();

                        usuario.Login = usuarioDTO.Login;
                        usuario.Email = usuarioDTO.Email;
                        usuario.NombreCompleto = usuarioDTO.NombreCompleto;
                        usuario.FechaCreacion = DateTime.Now;
                        usuario.Disponible = false;
                        usuario.FechaInactivacion = null;
                        usuario.SeccionalId = usuarioDTO.SeccionalId;
                        usuario.MaestroId = maestro.Id;
                        usuario.Disponible = usuarioDTO.Disponible;

                        db.SaveChanges();

                        ActualizarPermisos(usuarioDTO, usuario);
                        ActualizarComisiones(usuarioDTO, usuario);

                        db.SaveChanges();

                        scope.Complete();

                        if (usuarioDTO.Id == 0)
                        {
                            var id = EncryptationService.Encrypt(usuario.Id.ToString());
                            var activationUrl = $"{usuarioDTO.Host}/CompletarRegistro?id={id}";

                            sendEmailCreacionUsuario(usuarioDTO, activationUrl, "");
                        }
                    }

                }
                else
                {
                    response.AddError("Usted no tiene permisos para crear usuarios");
                }
            }
            else
            {
                response.AddError("Usted no tiene permisos para crear usuarios");
            }


            return new JsonResult(response);
        }

        private void ActualizarPermisos(CreacionUsuarioDTO usuarioDTO, Usuario usuario)
        {
            foreach (var item in usuarioDTO.PermisosUsuario)
            {
                var permisoUsuario = db.PermisosUsuarios.FirstOrDefault(pu => pu.UsuarioId == usuario.Id && pu.PermisoId == item.PermisoId);

                if (item.Checked)
                {
                    if (permisoUsuario == null)
                    {
                        db.PermisosUsuarios.Add(new PermisoUsuario
                        {
                            PermisoId = item.PermisoId,
                            UsuarioId = usuario.Id,
                            Disponible = true,
                        });
                    }
                    else if (permisoUsuario.Disponible == false)
                    {
                        permisoUsuario.Disponible = true;
                    }
                }
                else
                {
                    if (permisoUsuario != null)
                    {
                        permisoUsuario.Disponible = false;
                    }
                }
            }
        }

        private void ActualizarComisiones(CreacionUsuarioDTO usuarioDTO, Usuario usuario)
        {
            foreach (var item in usuarioDTO.ComisionesAprobacion)
            {
                var comisionAprobacionUsuario = db.UsuarioComisionAprobacion.FirstOrDefault(pu => pu.UsuarioId == usuario.Id && pu.ComisionAprobacionId == item.ComisionAprobacionId);

                if (item.Checked)
                {
                    if (comisionAprobacionUsuario == null)
                    {
                        db.UsuarioComisionAprobacion.Add(new UsuarioComisionAprobacion
                        {
                            ComisionAprobacionId = item.ComisionAprobacionId,
                            UsuarioId = usuario.Id,
                            UsuarioCreacionId = this.UsuarioId,
                            FechaCreacion = DateTime.Now,
                            Disponible = true
                        });
                    }
                    else if (comisionAprobacionUsuario.Disponible == false)
                    {
                        comisionAprobacionUsuario.Disponible = true;
                    }
                }
                else
                {
                    if (comisionAprobacionUsuario != null)
                    {
                        comisionAprobacionUsuario.Disponible = false;
                    }
                }
            }
        }


        public string sendEmailCreacionUsuario(CreacionUsuarioDTO usuarioDTO, string activationUrl, string cancelUrl)
        {
            var notifyEmail = bool.Parse(this._config["NotifyEmail"]);

            if (notifyEmail)
            {
                if (!string.IsNullOrEmpty(usuarioDTO.Email))
                {
                    var body = this.mailService.GetEmailTemplate(environment.ContentRootPath, MailTemplate.CreacionUsuario);

                    body = body.Replace("@email", usuarioDTO.Email);
                    body = body.Replace("@activationLink", activationUrl);
                    body = body.Replace("@cancelLink", cancelUrl);

                    mailService.SendEmail(body, "Notificacion Creación Usuario", usuarioDTO.Email);
                }

            }

            return "Ok";
        }

        [HttpGet]
        [Authorize]
        [Route("getUsuarioPorEmail")]
        public HttpDataResponse GetUsaurioPorEmail(string email)
        {
            HttpDataResponse response = new HttpDataResponse();

            if (!string.IsNullOrEmpty(email))
            {
                var usuario = db.Usuarios.FirstOrDefault(u => u.Email == email);

                if (usuario != null)
                {
                    response.Data = new CreacionUsuarioDTO
                    {
                        Email = usuario.Email,
                        NombreCompleto = usuario.NombreCompleto
                    };
                }
            }

            return response;
        }


        [HttpPost]
        [Authorize]
        [Route("consultaUsuarios")]
        public HttpDataResponse consultaUsuarios(FiltroDataUsuarioDTO filtro) 
        {
            var response = new HttpDataResponse();

            response.Data = usuariosService.GetDataConsulta(filtro);

            return response;
        }

        [HttpGet]
        [Authorize]
        [Route("GetDetalleUsuario")]
        public HttpDataResponse GetDetalleUsuario(int usuarioId) 
        {
            HttpDataResponse response = new HttpDataResponse();

            var usuario = usuariosService.GetById(usuarioId);

            if (usuario.Maestro == null) 
            {
                usuario.Maestro = new Maestro { };
            }

            response.Data = new CreacionUsuarioDTO
            {
                Cedula = usuario.Maestro.Cedula,
                NombreCompleto = usuario.NombreCompleto,
                Direccion = usuario.Maestro.Direccion,
                Cargo = usuario.Maestro.Cargo,
                Email = usuario.Email,
                FechaNacimiento = usuario.Maestro.FechaNacimiento,
                Login = usuario.Login,
                Sexo = usuario.Maestro.Sexo,
                SeccionalId = usuario.SeccionalId,
                Seccional = usuario.Seccional.Nombre,
                TelefonoCelular = usuario.Maestro.TelefonoCelular,
                TelefonoLabora = usuario.Maestro.TelefonoLabora,
                TelefonoResidencial = usuario.Maestro.TelefonoResidencial,
                PermisosUsuario = usuariosService.GetPermisosUsuario(usuarioId),
                ComisionesAprobacion = usuariosService.GetComisionesAprobacion(usuarioId),
                Disponible = usuario.Disponible
            };

            return response;
        }

        //[HttpGet]
        //[Authorize]
        //[Route("GetPermisos")]
        //public HttpDataResponse GetPermisos(int usuarioId) 
        //{
        //    HttpDataResponse response = new HttpDataResponse();

        //    try
        //    {
        //        response.Data = usuariosService.GetPermisosUsuario(usuarioId);
        //    }
        //    catch (Exception ex)
        //    {

        //        response.AddError(ex.Message);
        //    }
            
        //    return response; 
        //}

       
    }
}
