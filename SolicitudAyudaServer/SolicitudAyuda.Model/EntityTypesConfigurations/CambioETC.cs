using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class CambioETC : IEntityTypeConfiguration<Cambio>
    {
        public void Configure(EntityTypeBuilder<Cambio> entity)
        {
            entity.Property(p => p.Propiedad).HasMaxLength(150);
            entity.Property(p => p.Antes).HasMaxLength(4000);
            entity.Property(p => p.Despues).HasMaxLength(4000);
        }
    }
}
