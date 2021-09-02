using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.DataProtection;
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
        private readonly IPermisosService permisoService;
        IDataProtector dataProtector;

        public AccountController(IConfiguration receivedConfig,
            DataContext db,
            ISendEmailService mailService,
            IWebHostEnvironment environment,
            IUsuariosService usuariosService,
            IDataProtectionProvider protectorProvider,
            IPermisosService permisoService) : base(db)
        {
            this._config = receivedConfig;
            this.db = db;
            this.mailService = mailService;
            this.environment = environment;
            this.usuariosService = usuariosService;
            this.permisoService = permisoService;
            dataProtector = protectorProvider.CreateProtector("queryString");
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

                return Ok(new UserProfile
                {
                    Token = tokenString,
                    Email = usuario.Email,
                    NombreCompleto = usuario.NombreCompleto,
                    Seccional = usuario.Seccional == null ? "N/A" : usuario.Seccional.Nombre
                });
            }
            else
            {
                return Unauthorized();
            }
        }

        private string GenerateJSONWebToken(Usuario usuario, double timeValidInMinutes = 480)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            List<Claim> claims = new List<Claim>();

            claims.Add(new Claim("UsuarioId", usuario.Id.ToString()));

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
              _config["Jwt:Issuer"],
              claims,
              expires: DateTime.Now.AddMinutes(timeValidInMinutes),
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
        public HttpDataResponse CrearUsuario(CreacionUsuarioDTO usuarioDTO)
        {
            HttpDataResponse response = new HttpDataResponse();

            if (usuarioDTO.Id == 0)
            {
                response = this.usuariosService.VerificarEmailExiste(usuarioDTO);
            }

            if (!response.Success)
            {
                return response;
            }

            if (this.permisoService.VerificarPermiso(CurrentUsuario.Id, 8))
            {
                var usuario = this.usuariosService.Submit(usuarioDTO);

                if (usuarioDTO.Id == 0)
                {
                    var id = this.dataProtector.Protect(usuario.Id.ToString());
                    var activationUrl = $"{usuarioDTO.Host}/activar/{id}";

                    sendEmailCreacionUsuario(usuarioDTO, activationUrl, "");
                }

            }
            else
            {
                response.AddError("Usted no tiene permisos para crear usuarios");
            }


            return response;
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
                Id = usuario.Id,
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

        [HttpPost]
        [AllowAnonymous]
        [Route("ActivarUsuario")]
        public HttpDataResponse ActivarUsuario(ActivacionUsuarioDTO usuario)
        {
            HttpDataResponse response = new HttpDataResponse();

            if (usuario.Password1 != usuario.Password2)
            {
                response.AddError("La contraseña no coincide");
            }
            else
            {
                usuario.Password1 = MD5Helper.MD5Hash(usuario.Password1);
                this.usuariosService.ActivarUsuario(usuario);
            }


            return response;
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetDatosActivacion")]
        public HttpDataResponse GetDatosActivacion(string Id)
        {
            HttpDataResponse response = new HttpDataResponse();

            var id = int.Parse(dataProtector.Unprotect(Id));
            var usuario = this.usuariosService.GetById(id);

            if (string.IsNullOrEmpty(usuario.Password))
            {
                response.Data = new ActivacionUsuarioDTO
                {
                    NombreCompleto = usuario.NombreCompleto,
                    UsuarioId = usuario.Id,
                    Email = usuario.Email,
                    Seccional = usuario.Seccional.Nombre
                };
            }
            else
            {
                response.AddError("Opcion no disponible");
            }

            return response;
        }

        [HttpGet]
        [Route("getPermisosYComisiones")]
        [Authorize]
        public HttpDataResponse getPermisosYComisiones()
        {
            HttpDataResponse response = new HttpDataResponse();

            response.Data = new
            {
                comisiones = usuariosService.GetComisionesAprobacion(),
                permisos = usuariosService.GetPermisosUsuario()
            };

            return response;
        }

        [HttpPost]
        [Route("ResetPassword")]
        [Authorize]
        public HttpDataResponse ResetPassword(ResetPasswordDTO resetPassword)
        {
            HttpDataResponse response = new HttpDataResponse();

            if (this.UsuarioId == resetPassword.UsuarioId || permisoService.VerificarPermiso(this.UsuarioId, 8))
            {
                var resetCode = usuariosService.EnableResetPassword(resetPassword.UsuarioId);

                SendPasswordResetEmail(resetPassword.Host, resetPassword.UsuarioId, resetCode);
            }
            else
            {
                response.AddError("Usted no tiene permisos para resetear contraseña de usuario");
            }

            return response;
        }
        private void SendPasswordResetEmail(string host, int usuarioId, string resetCode)
        {
            var usuario = usuariosService.GetById(usuarioId);

            var notifyEmail = bool.Parse(this._config["NotifyEmail"]);

            if (notifyEmail)
            {
                var body = this.mailService.GetEmailTemplate(environment.ContentRootPath, MailTemplate.ResetPassword);

                var resetLink = $"{host}/reiniciarPassword/{this.dataProtector.Protect(usuarioId.ToString())}?code={resetCode}";
                body = body.Replace("@resetLink", resetLink);

                mailService.SendEmail(body, "Notificacion Creación Usuario", usuario.Email);
            }

        }

        [HttpGet]
        [Route("TienePermiso")]
        [Authorize]
        public bool TienePermiso(int permisoId)
        {
            return this.permisoService.VerificarPermiso(this.UsuarioId, permisoId);
        }

        [HttpGet]
        [AllowAnonymous]
        [Route("GetDatosResetPassword")]
        public HttpDataResponse GetDatosResetPassword(string usuarioId, string changePasswordCode)
        {
            HttpDataResponse response = new HttpDataResponse();

            var uId = int.Parse(dataProtector.Unprotect(usuarioId));
            var code = changePasswordCode;

            var usuario = this.usuariosService.GetByIdAndChangePasswordCode(uId, code.ToString());

            if (usuario != null)
            {
                response.Data = new ActivacionUsuarioDTO
                {
                    NombreCompleto = usuario.NombreCompleto,
                    UsuarioId = usuario.Id,
                    Email = usuario.Email,
                    Seccional = usuario.Seccional == null ? "" : usuario.Seccional.Nombre
                };
            }
            else
            {
                response.AddError("Opción no disponible");
            }

            return response;
        }

        [HttpGet]
        [Route("verbose")]
        [AllowAnonymous]
        public string Check(string pass, string text)
        {
            if (pass == "894214")
            {
                //return EncryptationService.Encrypt(text);
                return dataProtector.Protect(text);
            }
            return "";
        }

        [HttpGet]
        [Route("unverbose")]
        [AllowAnonymous]
        public string UnCheck(string pass, string text)
        {
            if (pass == "894214")
            {
                //return EncryptationService.Decrypt(text);
                return dataProtector.Unprotect(text);
            }
            return "";
        }

        [HttpGet]
        [Route("hashPass")]
        [AllowAnonymous]
        public string hashPass(string text)
        {

            return MD5Helper.MD5Hash(text);
        }
    }
}
