using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class RequisitoSolicitudETC : IEntityTypeConfiguration<RequisitoSolicitud>
    {
        public void Configure(EntityTypeBuilder<RequisitoSolicitud> entity)
        {
            entity.Property(e => e.Value).HasMaxLength(255);

            entity.HasOne(rs => rs.RequisitoTipoSolicitud)
                .WithMany(rt => rt.RequisitosSolicitudes)
                .HasForeignKey(rs => rs.RequisitoTiposSolicitudId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
