using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class ComisionAprobacionETC : IEntityTypeConfiguration<ComisionAprobacion>
    {
        public void Configure(EntityTypeBuilder<ComisionAprobacion> entity)
        {
            entity.ToTable("ComisionesAprobacion");
            entity.Property(c => c.Nombre).HasMaxLength(100);

            entity.HasMany(c => c.TiposSolicitudes).WithOne(ts => ts.ComisionAprobacion).HasForeignKey(ts => ts.ComisionAprobacionId);

            entity.HasMany(c => c.UsuariosComisionAprobacion).WithOne(uc => uc.ComisionAprobacion).HasForeignKey(uc => uc.ComisionAprobacionId);

            entity.HasData(new ComisionAprobacion 
            {
                Id = 1,
                Nombre = "Comision de Salud",                
            });
            
            entity.HasData(new ComisionAprobacion
            {
                Id = 2,
                Nombre = "Comision de Infraestructura",
            });
        }
    }
}
