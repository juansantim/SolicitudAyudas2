using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class MaestroETC : IEntityTypeConfiguration<Maestro>
    {
        public void Configure(EntityTypeBuilder<Maestro> entity)
        {
            entity.ToTable("Maestros");

            entity.Property(p => p.TelefonoCelular).HasMaxLength(10);
            entity.Property(p => p.TelefonoLabora).HasMaxLength(10);
            entity.Property(p => p.TelefonoResidencial).HasMaxLength(10);

            entity.Property(p => p.Sexo).HasMaxLength(1);
            entity.Property(p => p.Cedula).HasMaxLength(11);

            entity.Property(p => p.Direccion).HasMaxLength(500);
        }
    }
}
