using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class AprobacionSolicitudETC : IEntityTypeConfiguration<AprobacionSolicitud>
    {
        public void Configure(EntityTypeBuilder<AprobacionSolicitud> entity)
        {
            entity.ToTable("AprobacionesSolicitudes");

            entity.HasOne(ap => ap.Usuario).WithMany(u => u.AprobacionesSolicitudes).OnDelete(DeleteBehavior.NoAction);            
        }
    }
}
