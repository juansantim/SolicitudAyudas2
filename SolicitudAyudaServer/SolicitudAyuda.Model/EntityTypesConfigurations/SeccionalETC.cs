using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class SeccionalETC : IEntityTypeConfiguration<Seccional>
    {
        public void Configure(EntityTypeBuilder<Seccional> entity)
        {
            entity.Property(e => e.Nombre).HasMaxLength(100);
            
            entity.HasMany(e => e.Maestros).WithOne(m => m.Seccional).IsRequired(true);

            //string data
            //entity.HasData()

        }
    }
}
