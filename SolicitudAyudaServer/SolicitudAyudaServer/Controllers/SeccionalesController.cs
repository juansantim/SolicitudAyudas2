using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SolicitudAyuda.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolicitudAyudaServer.Controllers
{
    [Authorize]
    public class SeccionalesController: ControllerBase
    {
        private readonly DataContext db;

        public SeccionalesController(DataContext db)
        {
            this.db = db;
        }

        [Route("api/seccionales")]
        public dynamic Get() 
        {
            return db.Seccionales.Select(s => new 
            {
                s.Id,
                Nombre = $"{s.Municipio.Provincia.Nombre} - {s.Nombre}"
            }).ToList();
        }


        [Route("api/seccionalesByTerm")]
        public dynamic seccionalesByTerm(string term)
        {
            return db.Seccionales.Where(s => s.Nombre.Contains(term)).Select(s => new
            {
                s.Id,
                Nombre = $"{s.Municipio.Provincia.Nombre} - {s.Nombre}"
            }).ToList();
        }
        
    }
}
