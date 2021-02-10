using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;
using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class SeccionalETC : IEntityTypeConfiguration<Seccional>
    {
        public void Configure(EntityTypeBuilder<Seccional> entity)
        {
            entity.Property(e => e.Nombre).HasMaxLength(100);
            
            entity.HasMany(e => e.Maestros).WithOne(m => m.Seccional).IsRequired(true);

            //data
            var path = $"{ Environment.CurrentDirectory}\\seccionales.json";
            Console.WriteLine(path);
            var strData = System.IO.File.ReadAllText(path);
            var seccionalesDto = JsonConvert.DeserializeObject<List<SeccionalesSeedDto>>(strData);

            List<Seccional> seccionales = seccionalesDto.Select(a => new Seccional 
            {
                Id = a.Id,
                Nombre = a.Municipio,
                MunicipioId = a.MunicipioId,
                PresidenteId = null
            }).ToList();

            entity.HasData(seccionales);
        }
    }
}
