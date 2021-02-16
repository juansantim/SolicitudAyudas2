using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Entities;
using SolicitudAyuda.Model.Services.Signatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolicitudAyuda.Model.Services
{
    public class SolicitudesService : ISolicitudesService
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
            var solicitud = db.Solicitudes
                .Include(sl => sl.Requisitos)
                .Include(sl => sl.Adjuntos)
                .Include(sl => sl.Seccional)
                .Include(sl => sl.TipoSolicitud)
                .Include(sl => sl.Estado)
                .Include(sl => sl.Maestro).Single(s => s.Id == solicitudId);

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
                solicitud.EstadId,
                estado = solicitud.Estado.Nombre,
                tipoSolicitud = solicitud.TipoSolicitud.Nombre,
                Requisitos = solicitud.Requisitos.Select(rq => GetRequisitosParaDetalle(rq)),
                Adjuntos = solicitud.Adjuntos.Select(ad => GetAdjunto(ad))

            };
        }

        private dynamic GetRequisitosParaDetalle(RequisitoSolicitud requisito)
        {
            var tipo = db.RequisitosTipoSolicitudes.Single(rq => rq.Id == requisito.RequisitoTiposSolicitudId);

            return new
            {
                requisito.Id,
                Nombre = tipo.Descripcion,
                requisito.Value
            };
        }

        private dynamic GetAdjunto(AdjuntosSolicitud ad)
        {
            var fileName = System.IO.Path.GetFileName(ad.URL);

            return new
            {
                ad.Id,
                ad.ContentType,
                ad.SizeMB,
                ad.DisplayName
            };
        }

        public PaginatedResult<SolicitudConsultaDTO> GetDataConsulta(FiltroSolicitudesDTO filtro)
        {
            PaginatedResult<SolicitudConsultaDTO> result = new PaginatedResult<SolicitudConsultaDTO>();

            var query = db.Solicitudes
                .Include(sc => sc.Maestro)
                .Include(sc => sc.TipoSolicitud)
                .Include(sc => sc.Estado).AsQueryable();

            if (!string.IsNullOrEmpty(filtro.cedula))
            {
                query = query.Where(q => q.CedulaSolicitante == filtro.cedula);
            }

            if (filtro.seccionalId > 0)
            {
                query = query.Where(q => q.SeccionalId == filtro.seccionalId);
            }

            if (filtro.solicitudDesde.HasValue)
            {
                query = query.Where(q => q.FechaSolicitud >= filtro.solicitudDesde);
            }

            if (filtro.solicitudHasta.HasValue)
            {
                query = query.Where(q => q.FechaSolicitud <= filtro.solicitudHasta);
            }

            decimal itemsCount = query.Any() ? query.Count() : 0;

            query = query.Skip((filtro.Page - 1) * filtro.ItemsPerPage).Take(filtro.ItemsPerPage);

            if (itemsCount > 0)
            {
                result.TotalItems =Convert.ToInt32(itemsCount);
                //result.TotalItems = Convert.ToInt32(Math.Ceiling(itemsCount / Convert.ToDecimal(filtro.ItemsPerPage)));
            }

            result.Data = query.Select(sc => new SolicitudConsultaDTO
            {
                Id = sc.Id,
                Cedula = sc.CedulaSolicitante,
                TipoSolicitud = sc.TipoSolicitud.Nombre,
                Solicitante = sc.Maestro.NombreCompleto,
                Estado = sc.Estado.Nombre,
                MontoSolicitado = sc.MontoSolicitado,
                MontoAprobado = sc.MontoAprobado ?? 0
            }).ToList();

            return result;
        }
    }
}
