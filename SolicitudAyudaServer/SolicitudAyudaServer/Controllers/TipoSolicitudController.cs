using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolicitudAyuda.Model;
using SolicitudAyuda.Model.Entities;
using SolicitudAyuda.Model.Services.Signatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolicitudAyudaServer.Controllers
{
    public class TipoSolicitudController : ControllerBase
    {
        private readonly DataContext db;
        private readonly ISolicitudesService solicitudService;

        public TipoSolicitudController(DataContext db, ISolicitudesService solicitudService)
        {
            this.db = db;
            this.solicitudService = solicitudService;
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
                        r.Descripcion,
                        r.FormName,
                        value = "",
                        values = solicitudService.Getvalues(r)
                    })
                });
        }

      
    }
}
