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
        public DbSet<SolicitudAyuda.Model.Entities.SolicitudAyuda> Solicitudes { get; set; }
        public DbSet<Maestro> Maestros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AdjuntosSolicitud> AdjuntosSolicitudes { get; set; }

        public DbSet<PermisoUsuario> PermisosUsuarios { get; set; }

        public DbSet<UsuarioComisionAprobacion> UsuarioComisionAprobacion { get; set; }


        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasSequence<int>("NumeroExpendiente", schema: "dbo")
                .StartsAt(1)
                .IncrementsBy(1);

            modelBuilder.ApplyConfiguration(new ProvinciaETC());
            modelBuilder.ApplyConfiguration(new MunicipioETC());
            modelBuilder.ApplyConfiguration(new RequisitoTipoSolicitudETC());
            modelBuilder.ApplyConfiguration(new TipoSolicitudETC());
            modelBuilder.ApplyConfiguration(new SeccionalETC());
            modelBuilder.ApplyConfiguration(new SolicitudAyudaETC());
            modelBuilder.ApplyConfiguration(new EstadoSolicitudETC());
            modelBuilder.ApplyConfiguration(new UsuarioETC());
            modelBuilder.ApplyConfiguration(new PermisoETC());
            modelBuilder.ApplyConfiguration(new PermisoUsuarioETC());
            modelBuilder.ApplyConfiguration(new UsuarioComisionAprobacionETC());
            modelBuilder.ApplyConfiguration(new ComisionAprobacionETC());
        }
    }
}
