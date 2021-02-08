using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class ProvinciaETC : IEntityTypeConfiguration<Provincia>
    {
        public void Configure(EntityTypeBuilder<Provincia> entity)
        {
            entity.Property(p => p.Nombre).HasMaxLength(30);
            entity.HasMany(p => p.Municipios).WithOne(m => m.Provincia).HasForeignKey(m =>m.ProvinciaId);

            
            
            var strProvincias = System.IO.File.ReadAllText("")

        }
    }
}
