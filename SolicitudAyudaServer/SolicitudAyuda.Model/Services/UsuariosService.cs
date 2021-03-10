using Microsoft.EntityFrameworkCore;
using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Entities;
using SolicitudAyuda.Model.Services.Signatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolicitudAyuda.Model.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly DataContext db;

        public UsuariosService(DataContext db)
        {
            this.db = db;
        }

        public Usuario GetById(int usuarioId)
        {
            return db.Usuarios
                .Include(u => u.Seccional)
                .Include(u => u.Maestro)                
                .Include(u => u.PermisosUsuario)                
                .ThenInclude(pu => pu.Permiso).Single(u => u.Id == usuarioId);  
        }

        public PaginatedResult<UsuariosConsultaDTO> GetDataConsulta(FiltroDataUsuarioDTO filtro)
        {
            PaginatedResult<UsuariosConsultaDTO> result = new PaginatedResult<UsuariosConsultaDTO>();

            var query = db.Usuarios
                .Include(u => u.Seccional)
                .Include(u => u.PermisosUsuario)
                .ThenInclude(pu => pu.Permiso)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filtro.SearchText))
            {
                query = query.Where(q => 
                q.Email.Contains(filtro.SearchText) ||
                q.NombreCompleto.Contains(filtro.SearchText));
            }

            decimal itemsCount = query.Any() ? query.Count() : 0;

            query = query.Skip((filtro.Page - 1) * filtro.ItemsPerPage).Take(filtro.ItemsPerPage);

            if (itemsCount > 0)
            {
                result.TotalItems = Convert.ToInt32(itemsCount);
            }

            result.Data = query.Select(u => new UsuariosConsultaDTO
            {
                Id = u.Id,
                NombreCompleto = u.NombreCompleto,
                Disponible = u.Disponible,
                Email = u.Email,
                Seccional = u.Seccional.Nombre,
                SeccionalId = u.SecconalId,
                Permisos = u.PermisosUsuario.Where(pu => pu.Disponible).Select(pu => pu.Permiso.Nombre).ToList()
            }).ToList();

            return result;
        }
    }
}
