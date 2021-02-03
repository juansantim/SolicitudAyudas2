using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolicitudAyuda.Model;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolicitudAyudaServer.Controllers
{
    public class TipoSolicitudController : ControllerBase
    {
        private readonly DataContext db;

        public TipoSolicitudController(DataContext db)
        {
            this.db = db;
        }

        [Route("api/TipoSolicitud/ConRequisitos")]
        public dynamic GetTipoSolicitudesConRequisitos()
        {
            return db.TiposSolicitiudes
                .Include(d => d.Requisitos).Select(ts => new
                {
                    ts.Id,
                    ts.Nombre,
                    Requisitos = ts.Requisitos.Select(r => new
                    {
                        r.Id,
                        r.Nombre,
                        Checked = false,
                        values = Getvalues(r)
                    })
                });
        }

        private static List<string> Getvalues(RequisitoTipoSolicitud r)
        {
            return string.IsNullOrEmpty(r.PossibleValues) ? new List<string>() : r.PossibleValues.Split(",").ToList();
        }
    }
}
