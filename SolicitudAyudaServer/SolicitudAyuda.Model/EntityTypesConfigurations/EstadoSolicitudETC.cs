using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class EstadoSolicitudETC : IEntityTypeConfiguration<EstadoSolicitud>
    {
        public void Configure(EntityTypeBuilder<EstadoSolicitud> entity)
        {
            entity.Property(es => es.Nombre).HasMaxLength(100);
            entity.Property(es => es.Descripcion).HasMaxLength(255);

            
            entity.HasData(new EstadoSolicitud { Id = 1, Nombre = "Solicitado", Descripcion = "La solicitud se encuentra en cola para ser atendida." });
            entity.HasData(new EstadoSolicitud { Id = 2, Nombre = "Proceso de Aprobación", Descripcion = "La solicitud ha sido aprobada al menos por 1 miembro de la comisión" });
            entity.HasData(new EstadoSolicitud { Id = 3, Nombre = "Aprobado", Descripcion = "La solicitud ha sido aprobada y se encuentra en proceso de ser aplicada." });
            entity.HasData(new EstadoSolicitud { Id = 4, Nombre = "Rechazado", Descripcion = "La solicitud no procede según las políticas establecidas." });
            entity.HasData(new EstadoSolicitud { Id = 5, Nombre = "Anulado", Descripcion = "Solicitud fue descartada." });
        }
    }
}
