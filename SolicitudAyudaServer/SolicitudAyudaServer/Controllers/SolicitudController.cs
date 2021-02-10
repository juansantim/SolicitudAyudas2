using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using SolicitudAyuda.Model.Entities;

namespace SolicitudAyudaServer.Controllers
{
    public class SolicitudController : ControllerBase
    {
        [HttpPost]
        [Route("api/Solicitud/post")]
        public dynamic post([FromForm] SolicitudAyuda.Model.Entities.SolicitudAyuda solicitud) 
        {
            var requisitosJson = HttpContext.Request.Form["Requisitos"].ToString();
            solicitud.Requisitos = JsonConvert.DeserializeObject<List<RequisitoSolicitud>>(requisitosJson);

            if (HttpContext.Request.Form.Files.Count > 0) 
            {
                var physicalFileName = Guid.NewGuid();
            }

            return "ok";
        }
    }
}
