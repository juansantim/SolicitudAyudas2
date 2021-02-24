using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolicitudAyuda.Model;
using SolicitudAyuda.Model.DTOs;

namespace SolicitudAyudaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaestrosController : ControllerBase
    {
        private readonly DataContext db;

        public MaestrosController(DataContext db)
        {
            this.db = db;
        }

        [HttpGet]
        [Route("porcedula")]
        public HttpDataResponse porcedula(string cedula) 
        {
            HttpDataResponse response = new HttpDataResponse();

            var maestro = db.Maestros
                .Include(m => m.Seccional).FirstOrDefault(m => m.Cedula == cedula);

            if (maestro != null) 
            {
                response.Data = new
                {
                    maestro.Id,
                    maestro.Cedula,
                    maestro.NombreCompleto,
                    maestro.SeccionalId,
                    Seccional = maestro.Seccional.Nombre,
                    maestro.FechaNacimiento,
                    maestro.Sexo,
                    maestro.Cargo
                };
            }

            return response;
        }
    }
}
