using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class UsuarioComisionAprobacionETC : IEntityTypeConfiguration<UsuarioComisionAprobacion>
    {
        public void Configure(EntityTypeBuilder<UsuarioComisionAprobacion> entity)
        {
            entity.ToTable("UsuariosComisionesAprobacion");

            entity.HasData(new UsuarioComisionAprobacion 
            {
                Id = 1,
                UsuarioId = 3,
                ComisionAprobacionId = 1,
                Disponible = true,
                FechaCreacion = DateTime.Now,    
            });

            entity.HasData(new UsuarioComisionAprobacion
            {
                Id = 2,
                UsuarioId = 4,
                ComisionAprobacionId = 1,
                Disponible = true,
                FechaCreacion = DateTime.Now,
            });

            entity.HasData(new UsuarioComisionAprobacion
            {
                Id = 3,
                UsuarioId = 2,
                ComisionAprobacionId = 1,
                Disponible = true,
                FechaCreacion = DateTime.Now,
            });
        }
    }
}
