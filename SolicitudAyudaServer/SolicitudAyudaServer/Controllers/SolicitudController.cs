using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using SolicitudAyuda.Model;
using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Entities;

namespace SolicitudAyudaServer.Controllers
{
    public class SolicitudController : ControllerBase
    {
        private IConfiguration _config;
        private DataContext _db;
        public SolicitudController(IConfiguration configuration, DataContext db)
        {
            this._config = configuration;
            this._db = db;
        }

        [HttpPost]
        [Route("api/Solicitud/post")]
        public dynamic post([FromForm] SolicitudAyuda.Model.Entities.SolicitudAyuda solicitud)
        {
            HttpResponse response = new HttpResponse();
            
            try
            {
                var requisitosJson = HttpContext.Request.Form["Requisitos"].ToString();
                var maestroDto = JsonConvert.DeserializeObject<MaestroDto>(HttpContext.Request.Form["MaestroDTO"].ToString());

                solicitud.Requisitos = JsonConvert.DeserializeObject<List<RequisitoSolicitud>>(requisitosJson);
                solicitud.EstadId = 1;

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
                        Sexo = maestroDto.Sexo
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
                            URL = $"{filesUrl}\\{physicalFileName}.{extension}",
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
                
                response.Data = new { solicitudId = solicitud.Id };
            }
            catch (Exception ex)
            {
                response.Errors.Add(ex.Message);
            }

            return response;
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
    }
}
