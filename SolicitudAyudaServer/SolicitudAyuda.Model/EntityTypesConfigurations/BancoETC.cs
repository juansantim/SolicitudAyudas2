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
    class BancoETC : IEntityTypeConfiguration<Banco>
    {
        public void Configure(EntityTypeBuilder<Banco> entity)
        {
            entity.Property(p => p.Nombre).HasMaxLength(50);

            var path = $"{ Environment.CurrentDirectory}{Path.AltDirectorySeparatorChar}bancos.json";
            Console.WriteLine(path);
            var strBancos = System.IO.File.ReadAllText(path);

            var data = JsonConvert.DeserializeObject<List<Banco>>(strBancos);

            entity.HasData(data);
        }
    }
}
