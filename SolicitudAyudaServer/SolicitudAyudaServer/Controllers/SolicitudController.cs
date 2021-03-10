using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SolicitudAyuda.Model;
using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Entities;
using SolicitudAyuda.Model.Services;
using SolicitudAyuda.Model.Services.Signatures;

namespace SolicitudAyudaServer.Controllers
{
    [Authorize]
    public class SolicitudController : ControllerBase
    {
        private IConfiguration _config;
        private DataContext db;
        private readonly ISolicitudesService service;
        private readonly ISendEmailService mailService;
        private readonly IFileStorageService fileStorageService;
        private readonly IWebHostEnvironment environment;

        public int UsuarioId
        {
            get
            {
                if (User != null)
                {
                    if (User.Claims.Count() > 0)
                    {
                        return int.Parse(User.Claims.Where(c => c.Type == "UsuarioId").FirstOrDefault().Value);
                    }
                }

                throw new InvalidOperationException("Usuario o autenticado"); ;
            }
        }

        public SolicitudController(IConfiguration configuration,
            DataContext db,
            ISolicitudesService service,
            ISendEmailService mailService,
            IFileStorageService fileStorageService, IWebHostEnvironment environment)
        {
            this._config = configuration;
            this.db = db;
            this.service = service;
            this.mailService = mailService;
            this.fileStorageService = fileStorageService;
            this.environment = environment;
        }

        [HttpPost]
        [Route("api/Solicitud/post")]
        public dynamic post([FromForm] SolicitudAyuda.Model.Entities.SolicitudAyuda solicitud)
        {
            HttpDataResponse response = new HttpDataResponse();

            try
            {
                var requisitosJson = HttpContext.Request.Form["Requisitos"].ToString();
                var maestroDto = JsonConvert.DeserializeObject<MaestroDto>(HttpContext.Request.Form["MaestroDTO"].ToString());

                solicitud.Requisitos = JsonConvert.DeserializeObject<List<RequisitoSolicitud>>(requisitosJson);
                solicitud.EstadoId = 1;

                var usuarioId = int.Parse(User.Claims.Single(cl => cl.Type == "UsuarioId").Value);
                solicitud.UsuarioId = usuarioId;
                solicitud.FechaSolicitud = DateTime.Now;

                Maestro maestro;

                if (db.Maestros.Any(ma => ma.Cedula == maestroDto.Cedula))
                {
                    maestro = db.Maestros.Single(m => m.Cedula == maestroDto.Cedula);
                }
                else
                {
                    maestro = new Maestro
                    {
                        Cedula = maestroDto.Cedula,
                        NombreCompleto = maestroDto.NombreCompleto,
                        Cargo = maestroDto.Cargo,
                        SeccionalId = maestroDto.SeccionalId,
                        Sexo = maestroDto.Sexo,
                        FechaNacimiento = maestroDto.FechaNacimiento,
                        Direccion = solicitud.Direccion,
                        TelefonoCelular = solicitud.Celular,
                        TelefonoLabora = solicitud.TelefonoTrabajo,
                        TelefonoResidencial = solicitud.TelefonoCasa,
                    };
                }

                solicitud.Maestro = maestro;

                List<FileDataDTO> files = new List<FileDataDTO>();

                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    foreach (var file in HttpContext.Request.Form.Files)
                    {
                        files.Add(new FileDataDTO
                        {
                            OriginalFileName = file.FileName,
                            Content = file.OpenReadStream(),
                            ContenType = file.ContentType
                        });
                    }
                }

                using (TransactionScope scope = new TransactionScope())
                {
                    db.Solicitudes.Add(solicitud);
                    db.SaveChanges();

                    scope.Complete();
                }

                fileStorageService.SaveFiles(solicitud, files);

                sendEmail(solicitud);

                response.Data = new { solicitudId = solicitud.Id };
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }

            return response;
        }

        [HttpGet]
        [Route("api/Solicitud/detalle")]
        public dynamic getDetalleSolicitud(int solicitudId)
        {
            var solicitud = service.GetDetalleSolicitud(solicitudId, UsuarioId);

            return solicitud;
        }

        [HttpPost]
        [Route("api/Solicitud/paginada")]
        public dynamic getData([FromBody] dynamic filtro)
        {
            var filtro2 = JsonConvert.DeserializeObject<FiltroSolicitudesDTO>(filtro.ToString());
            return service.GetDataConsulta(filtro2);
        }

        public string sendEmail(SolicitudAyuda.Model.Entities.SolicitudAyuda solicitud)
        {
            var notifyEmail = bool.Parse(this._config["NotifyEmail"]);

            if (notifyEmail)
            {
                if (!string.IsNullOrEmpty(solicitud.Email))
                {
                    db.Entry(solicitud).Reference(sa => sa.TipoSolicitud).Load();
                    db.Entry(solicitud).Reference(sa => sa.Maestro).Load();

                    var body = this.mailService.GetEmailTemplate(environment.ContentRootPath, MailTemplate.CreacionSolicitud);

                    body = body.Replace("{@maestro}", solicitud.Maestro.NombreCompleto);
                    body = body.Replace("{@NumeroExpendiente}", solicitud.NumeroExpediente.ToString());
                    body = body.Replace("{@montoSolicitado}", solicitud.MontoSolicitado.ToString("N2"));
                    body = body.Replace("{@concepto}", $"{solicitud.TipoSolicitud.Nombre}: {solicitud.Concepto}");

                    mailService.SendEmail(body, "Notificacion de Solicitud de Ayuda", solicitud.Email);
                }

            }

            return "Ok";
        }

        [HttpPost]
        [Route("api/Solicitud/ProcesarSolicitud")]
        [Produces("application/json")]
        public HttpDataResponse ProcesarSolicitud([FromBody] ProcesarSolicitudDTO datosProcesamiento)
        {
            HttpDataResponse response = new HttpDataResponse();
            //ProcesarSolicitudDTO datosProcesamiento = JsonConvert.DeserializeObject<ProcesarSolicitudDTO>((JsonConvert.SerializeObject(datos)));

            try
            {
                if (datosProcesamiento == null || datosProcesamiento.solicitudId == 0)
                {
                    response.Errors.Add("Número de solicitud inválido");

                    return response;
                }

                var solicitud = db.Solicitudes
                    .Include(s => s.AprobacionesSolicitud)
                    .Include(s => s.TipoSolicitud)
                    .ThenInclude(t => t.ComisionAprobacion).ThenInclude(c => c.UsuariosComisionAprobacion).Single(s => s.Id == datosProcesamiento.solicitudId);

                if (solicitud.EstadoId == 4)
                {
                    response.Errors.Add("Se encuentra rechazada");

                    return response;
                }

                IEnumerable<int> usuariosYaAprobaron = GetUsuariosAprobaron(solicitud);

                var usuariosComision = solicitud.TipoSolicitud.ComisionAprobacion.UsuariosComisionAprobacion.Select(s => s.UsuarioId);

                var usuarioId = int.Parse(User.Claims.Where(c => c.Type == "UsuarioId").FirstOrDefault().Value);

                if (usuariosYaAprobaron.Any(ua => ua == usuarioId))
                {
                    response.Errors.Add("Ya usted procesó esta solicitud");
                }
                else if (!usuariosComision.Any(uc => uc == usuarioId))
                {
                    response.Errors.Add("Usted no puede aprobar este tipo ayuda");
                }
                else
                {
                    usuariosYaAprobaron = GetUsuariosAprobaron(solicitud);

                    var hayPendientes = false;
                    foreach (var uc in usuariosComision)
                    {
                        if (!usuariosYaAprobaron.Any(ua => ua == uc))
                        {
                            hayPendientes = true;
                        }
                    }

                    if (datosProcesamiento.estadoId == 3)
                    {
                        if (hayPendientes)
                        {
                            solicitud.EstadoId = 2;
                        }
                        else
                        {
                            solicitud.EstadoId = 3;
                        }
                    }
                    else if (datosProcesamiento.estadoId == 4)
                    {
                        solicitud.EstadoId = 4;
                        datosProcesamiento.comentario += " *-Solicitud se rechaza por rechazo de un solo miembro de la comision-*";
                    }

                    solicitud.AprobacionesSolicitud.Add(new AprobacionSolicitud
                    {
                        Fecha = DateTime.Now,
                        UsuarioId = usuarioId,
                        EstadoId = datosProcesamiento.estadoId,
                        Comentario = datosProcesamiento.comentario
                    });


                    db.SaveChanges();
                }

            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }

            return response;

        }

        private static IEnumerable<int> GetUsuariosAprobaron(SolicitudAyuda.Model.Entities.SolicitudAyuda solicitud)
        {
            return solicitud.AprobacionesSolicitud.Select(s => s.UsuarioId);
        }

        public static byte[] GetBytes(Stream input)
        {
            byte[] buffer = new byte[16 * 1024];
            using (MemoryStream ms = new MemoryStream())
            {
                int read;
                while ((read = input.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, read);
                }
                return ms.ToArray();
            }
        }

        [HttpGet]
        [Route("api/Solicitud/Imprimir")]
        [AllowAnonymous]
        public FileResult Imprimir(int solicitudId, int formato)
        {
            var data = this.service.ImprimirPDF(solicitudId, formato);

            MemoryStream resultStream = new MemoryStream(data);

            FileStreamResult resultPDF = new FileStreamResult(resultStream, "application/pdf");
            return resultPDF;
        }
    }
}
