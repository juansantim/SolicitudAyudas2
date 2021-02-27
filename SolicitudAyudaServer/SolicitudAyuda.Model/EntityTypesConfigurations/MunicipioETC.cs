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
    public class MunicipioETC : IEntityTypeConfiguration<Municipio>
    {
        public void Configure(EntityTypeBuilder<Municipio> entity)
        {
            entity.Property(e => e.Nombre).HasMaxLength(40);


            var path = $"{ Environment.CurrentDirectory}{Path.AltDirectorySeparatorChar}municipios.json";
            Console.WriteLine(path);
            var strProvincias = System.IO.File.ReadAllText(path);
            var provincias = JsonConvert.DeserializeObject<List<Municipio>>(strProvincias);

            entity.HasData(provincias);
        }
    }
}
