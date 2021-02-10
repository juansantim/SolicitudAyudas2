using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SolicitudAyuda.Model.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class SolicitudAyudaETC : IEntityTypeConfiguration<SolicitudAyuda.Model.Entities.SolicitudAyuda>
    {
        public void Configure(EntityTypeBuilder<Entities.SolicitudAyuda> entity)
        {
            entity.HasOne(sa => sa.Maestro).WithMany(ma => ma.Solicitudes).HasForeignKey(sa => sa.MaestroId);

            entity.HasOne(sa => sa.TipoSolicitud).WithMany(ts => ts.Solicitudes).HasForeignKey(sa => sa.TipoSolicitudId);

            entity.HasMany(sa => sa.Requisitos).WithOne(r => r.SolicitudAyuda).HasForeignKey(x => x.SolicitudAyudaId);
            entity.HasMany(sa => sa.Adjuntos).WithOne(r => r.SolicitudAyuda).HasForeignKey(x => x.SolicitudAyudaId);

            entity.HasOne(sa => sa.Estado).WithMany(es => es.SolicitudesAyuda).HasForeignKey(sa => sa.EstadId);

            entity.HasOne(sa => sa.Usuario).WithMany(es => es.SolicitudesAyuda).HasForeignKey(sa => sa.UsuarioId);

            entity.Property(sa => sa.CedulaSolicitante).IsRequired();

            entity .Property(o => o.NumeroExpediente)
                .HasDefaultValueSql("NEXT VALUE FOR shared.NumeroExpendiente");
        }
    }
}
