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
            entity.ToTable("TiposSolicitudes");
            entity.Property(e => e.Nombre).HasMaxLength(150);
            entity.HasMany(e => e.Requisitos).WithOne(r => r.TipoSolicitud).HasForeignKey(r => r.TipoSolicitudId);

            entity.HasOne(e => e.ComisionAprobacion).WithMany(sa => sa.TiposSolicitudes).HasForeignKey(sa => sa.ComisionAprobacionId);

    
            entity.HasData(
                new TipoSolicitud
                {
                    Id = 1,
                    Nombre = "Salud - Cancer", 
                    ComisionAprobacionId = 1,
                    CategoriaId = 1
                },
                new TipoSolicitud
                {
                    Id = 2,
                    Nombre = "Salud - Covid",
                    ComisionAprobacionId = 1,
                    CategoriaId = 1
                },
                new TipoSolicitud
                {
                    Id = 3,
                    Nombre = "Construccion",                    
                    ComisionAprobacionId = 2,
                    CategoriaId = 2
                });
        }
    }
}
