using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class ComentarioSolicitudETC : IEntityTypeConfiguration<ComentarioSolicitud>
    {
        public void Configure(EntityTypeBuilder<ComentarioSolicitud> entity)
        {
            entity.ToTable("ComentariosSolicitudes");

            entity.Property(c => c.Comentario).HasMaxLength(1000);

        }
    }
}
