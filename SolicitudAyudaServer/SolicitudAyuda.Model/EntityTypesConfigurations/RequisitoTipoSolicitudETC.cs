using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class RequisitoTipoSolicitudETC : IEntityTypeConfiguration<RequisitoTipoSolicitud>
    {
        public void Configure(EntityTypeBuilder<RequisitoTipoSolicitud> entity)
        {
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.Property(e => e.PossibleValues).HasColumnName("PossibleValues");
            entity.Property(e => e.PossibleValues).HasMaxLength(4000);
          
        }
    }
}
