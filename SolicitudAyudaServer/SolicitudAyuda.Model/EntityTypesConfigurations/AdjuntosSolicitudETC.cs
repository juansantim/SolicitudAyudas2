using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class AdjuntosSolicitudETC : IEntityTypeConfiguration<AdjuntosSolicitud>
    {
        public void Configure(EntityTypeBuilder<AdjuntosSolicitud> entity)
        {
            entity.Property(e => e.URL).HasMaxLength(500);
            entity.Property(e => e.DisplayName).HasMaxLength(255);
        }
    }
}
