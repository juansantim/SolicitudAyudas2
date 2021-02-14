using Microsoft.Extensions.Configuration;
using SolicitudAyuda.Model.Entities;
using SolicitudAyuda.Model.Services.Signatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolicitudAyuda.Model.Services
{
    public class SolicitudesService: ISolicitudesService
    {
        private readonly DataContext db;
        private readonly IConfiguration config;

        public SolicitudesService(DataContext db, IConfiguration config)
        {
            this.db = db;
            this.config = config;
        }

        public dynamic GetDetalleSolicitud(int solicitudId)
        {
            var solicitud = db.Solicitudes.Single(s => s.Id == solicitudId);

            return new
            {
                solicitud.Id,
                solicitud.CedulaSolicitante,
                Seccional = solicitud.Seccional.Nombre,
                NombreSolicitante = solicitud.Maestro.NombreCompleto,
                Edad = new DateTime((DateTime.Now - solicitud.Maestro.FechaNacimiento).Ticks).Year - 1,
                SexoSolicitante = solicitud.Maestro.Sexo,
                solicitud.Maestro.Cargo,
                solicitud.MontoSolicitado,
                solicitud.MontoAprobado,
                solicitud.TelefonoCasa,
                solicitud.Celular,
                solicitud.TelefonoTrabajo,
                solicitud.Email,
                solicitud.Direccion,
                Requisitos = solicitud.Requisitos.Select(rq => new { 
                    rq.Id,
                    rq.RequisitoTipoSolicitud.Descripcion,
                    rq.Value
                }),
                Adjuntos = solicitud.Adjuntos.Select(ad => GetAdjunto(ad))
                
            };
        }

        private dynamic GetAdjunto(AdjuntosSolicitud ad)
        {
            var fileName = System.IO.Path.GetFileName(ad.URL);            

            return new
            {
                ad.Id,
                ad.SizeMB,                
                ad.DisplayName
            };
        }
    }
}
