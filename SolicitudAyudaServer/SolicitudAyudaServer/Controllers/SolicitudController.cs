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
    [ApiController]
    public class SolicitudController : AppBaseController
    {
        private IConfiguration _config;
        private DataContext db;
        private readonly ISolicitudesService service;
        private readonly ISendEmailService mailService;
        private readonly IFileStorageService fileStorageService;
        private readonly IWebHostEnvironment environment;
        private readonly IPermisosService permisosService;

        public SolicitudController(IConfiguration configuration,
            DataContext db,
            ISolicitudesService service,
            ISendEmailService mailService,
            IFileStorageService fileStorageService,
            IWebHostEnvironment environment,
            IPermisosService permisosService) : base(db)
        {
            this._config = configuration;
            this.db = db;
            this.service = service;
            this.mailService = mailService;
            this.fileStorageService = fileStorageService;
            this.environment = environment;
            this.permisosService = permisosService;
        }

        [HttpPost]
        [Route("api/Solicitud/post")]
        public dynamic post([FromForm] SolicitudAyuda.Model.Entities.SolicitudAyuda solicitud)
        {
            HttpDataResponse response = new HttpDataResponse();

            try
            {
                solicitud.Id = int.Parse(string.IsNullOrEmpty(HttpContext.Request.Form["SolicitudId"][0]) ? "0" : HttpContext.Request.Form["SolicitudId"].ToString());

                if (solicitud.Id == 0)
                {
                    solicitud.Requisitos = JsonConvert.DeserializeObject<List<RequisitoSolicitud>>(HttpContext.Request.Form["Requisitos"].ToString());

                    var maestroDto = JsonConvert.DeserializeObject<MaestroDto>(HttpContext.Request.Form["MaestroDTO"].ToString());

                    solicitud.Maestro = service.GetMaestro(maestroDto, solicitud, response);

                    if (response.Success)
                    {
                        response = service.CreateSolicitud(solicitud, HttpContext.Request.Form.Files, UsuarioId);
                        sendEmail(solicitud);
                    }

                    return response;
                }
                else
                {
                    return service.Update(solicitud, HttpContext.Request.Form.Files, UsuarioId);

                }
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
        public dynamic getData(FiltroSolicitudesDTO filtro)
        {
            //var filtro2 = JsonConvert.DeserializeObject<FiltroSolicitudesDTO>(filtro.ToString());            
            return service.GetDataConsulta(filtro);
        }

        private string sendEmail(SolicitudAyuda.Model.Entities.SolicitudAyuda solicitud)
        {
            var notifyEmail = bool.Parse(this._config["NotifyEmail"]);

            if (notifyEmail)
            {
                try
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
                catch (Exception ex)
                {
                    throw;
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

        private static byte[] GetBytes(Stream input)
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


        [HttpPost]
        [Route("api/Solicitud/Anular")]
        [AllowAnonymous]
        public HttpDataResponse AnularSolicitud(int solicitudId)
        {
            HttpDataResponse response = new HttpDataResponse();

            var solicitud = db.Solicitudes.Single(s => s.Id == solicitudId);
            solicitud.EstadoId = 5;

            db.SaveChanges();

            return response;
        }

    }
}
