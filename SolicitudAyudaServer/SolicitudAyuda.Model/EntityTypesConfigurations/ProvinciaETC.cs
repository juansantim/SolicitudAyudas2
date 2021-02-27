using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class ProvinciaETC : IEntityTypeConfiguration<Provincia>
    {
        public ProvinciaETC()
        {

        }
        public void Configure(EntityTypeBuilder<Provincia> entity)
        {
            entity.Property(p => p.Nombre).HasMaxLength(30);
            entity.HasMany(p => p.Municipios).WithOne(m => m.Provincia).HasForeignKey(m =>m.ProvinciaId);


            var path = $"{ Environment.CurrentDirectory}{Path.AltDirectorySeparatorChar}provincias.json";
            Console.WriteLine(path);
            var strProvincias = System.IO.File.ReadAllText(path);
            var provincias = JsonConvert.DeserializeObject<List<Provincia>>(strProvincias);

            entity.HasData(provincias);
        }
    }
}
