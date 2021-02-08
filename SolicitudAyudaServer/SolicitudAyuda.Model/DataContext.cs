using Microsoft.EntityFrameworkCore;
using SolicitudAyuda.Model.Entities;
using SolicitudAyuda.Model.EntityTypesConfigurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model
{
    public class DataContext : DbContext
    {
        public DbSet<TipoSolicitud> TiposSolicitiudes { get; set; }
        public DbSet<RequisitoTipoSolicitud> RequisitosTipoSolicitudes { get; set; }
        public DbSet<Provincia> Provincias { get; set; }
        public DbSet<Municipio> Municipios { get; set; }
        public DbSet<Seccional> Seccionales { get; set; }


        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProvinciaETC());
            modelBuilder.ApplyConfiguration(new MunicipioETC());
            modelBuilder.ApplyConfiguration(new RequisitoTipoSolicitudETC());
            modelBuilder.ApplyConfiguration(new TipoSolicitudETC());
        }
    }
}
