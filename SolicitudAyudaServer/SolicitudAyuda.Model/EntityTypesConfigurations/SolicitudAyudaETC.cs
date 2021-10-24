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
            entity.Property(sa => sa.CedulaSolicitante).IsRequired().HasMaxLength(11);            
            entity.Property(s => s.TelefonoCasa).HasMaxLength(10);
            entity.Property(s => s.Celular).HasMaxLength(10);
            entity.Property(s => s.TelefonoTrabajo).HasMaxLength(10);
            entity.Property(sa => sa.Direccion).HasMaxLength(255);
            entity.Property(s => s.Email).HasMaxLength(50);
            entity.Property(s => s.Concepto).HasMaxLength(500);
            entity.Property(s => s.BancoId).HasDefaultValue(1);
            entity.Property(s => s.OtroTipoSolicitud).HasMaxLength(150);
            
            entity.Property(s => s.MontoSolicitado).HasColumnType("decimal(10, 2)");

            entity.Property(s => s.MontoAprobado).HasColumnType("decimal(10, 2)");

            entity.HasOne(sa => sa.Maestro).WithMany(ma => ma.Solicitudes).HasForeignKey(sa => sa.MaestroId);

            entity.HasOne(sa => sa.TipoSolicitud).WithMany(ts => ts.Solicitudes).HasForeignKey(sa => sa.TipoSolicitudId);

            entity.HasMany(sa => sa.Requisitos).WithOne(r => r.SolicitudAyuda).HasForeignKey(x => x.SolicitudAyudaId);
            
            entity.HasMany(sa => sa.Adjuntos).WithOne(r => r.SolicitudAyuda).HasForeignKey(x => x.SolicitudAyudaId);
            
            entity.HasMany(sa => sa.AprobacionesSolicitud).WithOne(ap => ap.SolicitudAyuda).HasForeignKey(ap => ap.SolicitudAyudaId);

            entity.HasMany(sa => sa.Comentarios).WithOne(c => c.SolicitudAyuda).HasForeignKey(c => c.SolicitudAyudaId).OnDelete(DeleteBehavior.NoAction);

            entity.HasOne(sa => sa.Estado).WithMany(es => es.SolicitudesAyuda).HasForeignKey(sa => sa.EstadoId);

            entity.HasOne(sa => sa.Usuario).WithMany(es => es.SolicitudesAyuda).HasForeignKey(sa => sa.UsuarioId);

            entity.HasOne(sa => sa.Banco).WithMany(b => b.SolicitudesAyuda).HasForeignKey(sa => sa.BancoId);

            entity.HasOne(sa => sa.Seccional).WithMany(sc => sc.SolicitudesAyuda)
                .HasForeignKey(sa => sa.SeccionalId)
                .OnDelete(DeleteBehavior.NoAction);

            entity.Property(o => o.NumeroExpediente)
                .HasDefaultValueSql("NEXT VALUE FOR dbo.NumeroExpendiente");

            entity.HasOne(s => s.SubTipoSolicitud).WithMany(st => st.SolicitudesAyudas).HasForeignKey(sa => sa.SubTipoSolicitudId);
        }
    }
}
