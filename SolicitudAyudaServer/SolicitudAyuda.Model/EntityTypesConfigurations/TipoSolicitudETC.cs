using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class TipoSolicitudETC : IEntityTypeConfiguration<TipoSolicitud>
    {
        public void Configure(EntityTypeBuilder<TipoSolicitud> entity)
        {
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.HasMany(e => e.Requisitos).WithOne(r => r.TipoSolicitud).HasForeignKey(r => r.TipoSolicitudId);
        }
    }
}
