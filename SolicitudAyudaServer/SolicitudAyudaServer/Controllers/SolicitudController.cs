using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Authorization;
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
        private DataContext _db;
        private readonly ISolicitudesService service;
        private readonly ISendEmailService mailService;
        public SolicitudController(IConfiguration configuration, DataContext db, ISolicitudesService service, ISendEmailService mailService)
        {
            this._config = configuration;
            this._db = db;
            this.service = service;
            this.mailService = mailService;
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

                if (_db.Maestros.Any(ma => ma.Cedula == maestroDto.Cedula))
                {
                    maestro = _db.Maestros.Single(m => m.Cedula == maestroDto.Cedula);
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
                        FechaNacimiento = maestroDto.FechaNacimiento
                    };
                }

                solicitud.Maestro = maestro;

                if (HttpContext.Request.Form.Files.Count > 0)
                {
                    var filesUrl = _config["FilesUrl"];
                    foreach (var file in HttpContext.Request.Form.Files)
                    {
                        var physicalFileName = Guid.NewGuid();
                        var extension = System.IO.Path.GetExtension(file.FileName);

                        solicitud.Adjuntos.Add(new AdjuntosSolicitud
                        {
                            SizeMB = (file.Length / 1024) / 1024,
                            DisplayName = file.FileName,
                            URL = $"{filesUrl}\\{physicalFileName}{extension}",
                            ContentType = file.ContentType,
                            Content = file.OpenReadStream()
                        });

                    }
                }

                using (TransactionScope scope = new TransactionScope())
                {
                    _db.Solicitudes.Add(solicitud);
                    _db.SaveChanges();

                    foreach (var item in solicitud.Adjuntos)
                    {
                        System.IO.File.WriteAllBytes(item.URL, GetBytes(item.Content));
                    }

                    scope.Complete();
                }

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
            var solicitud = service.GetDetalleSolicitud(solicitudId);

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
                    _db.Entry(solicitud).Reference(sa => sa.TipoSolicitud).Load();
                    _db.Entry(solicitud).Reference(sa => sa.Maestro).Load();

                    var body = this.mailService.GetEmailTemplate(MailTemplate.CreacionSolicitud);

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
        [Route("api/Solicitud/AprobarSolicitud")]
        [Produces("application/json")]
        public HttpDataResponse AprobarSolicitud()
        {
            HttpDataResponse response = new HttpDataResponse();

            try
            {
                var solicitudId = int.Parse(Request.Form["solicitudId"]);

                if (solicitudId == 0)
                {
                    throw new InvalidOperationException("Numero de soliciud inválido");
                }

                var solicitud = _db.Solicitudes
                    .Include(s => s.AprobacionesSolicitud)
                    .Include(s => s.TipoSolicitud)
                    .ThenInclude(t => t.ComisionAprobacion).ThenInclude(c => c.UsuariosComisionAprobacion).Single(s => s.Id == solicitudId);

                IEnumerable<int> usuariosYaAprobaron = GetUsuariosAprobaron(solicitud);

                var usuariosComision = solicitud.TipoSolicitud.ComisionAprobacion.UsuariosComisionAprobacion.Select(s => s.UsuarioId);

                var usuarioId = int.Parse(User.Claims.Where(c => c.Type == "UsuarioId").FirstOrDefault().Value);

                if (usuariosYaAprobaron.Any(ua => ua == usuarioId))
                {
                    throw new InvalidOperationException("Ya usted aprobó esta solicitud");
                }
                else if (!usuariosComision.Any(uc => uc == usuarioId))
                {
                    throw new InvalidOperationException("Usted no puede aprobar este tipo ayuda");
                }
                else
                {
                    solicitud.AprobacionesSolicitud.Add(new AprobacionSolicitud
                    {
                        FechaAprobacion = DateTime.Now,
                        UsuarioId = usuarioId,
                    });

                    usuariosYaAprobaron = GetUsuariosAprobaron(solicitud);

                    var hayPendientes = false;
                    foreach (var uc in usuariosComision)
                    {
                        if (!usuariosYaAprobaron.Any(ua => ua == uc))
                        {
                            hayPendientes = true;
                        }
                    }

                    if (hayPendientes)
                    {
                        solicitud.EstadoId = 2;
                    }
                    else
                    {
                        solicitud.EstadoId = 3;
                    }

                    _db.SaveChanges();
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
            var data = this.service.ImprimirPDF(solicitudId);

            MemoryStream resultStream = new MemoryStream(data);

            FileStreamResult resultPDF = new FileStreamResult(resultStream, "application/pdf");
            return resultPDF;
        }
    }
}
