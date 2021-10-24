using Microsoft.EntityFrameworkCore;
using SolicitudAyuda.Model.Entities;
using SolicitudAyuda.Model.EntityTypesConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public virtual DbSet<SolicitudAyuda.Model.Entities.SolicitudAyuda> Solicitudes { get; set; }
        public DbSet<Maestro> Maestros { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<AdjuntosSolicitud> AdjuntosSolicitudes { get; set; }

        public DbSet<PermisoUsuario> PermisosUsuarios { get; set; }

        public DbSet<UsuarioComisionAprobacion> UsuarioComisionAprobacion { get; set; }
        public DbSet<Permiso> Permisos { get; set; }
        public DbSet<ComisionAprobacion> ComisionesAprobacion { get; internal set; }

        public DbSet<Banco> Banco { get; set; }

        public DbSet<Movimiento> Movimientos { get; set; }


        public DbSet<SubTipoSolicitudAyuda> SubTiposSolicitudesAyuda { get; set; }
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
            modelBuilder.ApplyConfiguration(new AprobacionSolicitudETC());
            modelBuilder.ApplyConfiguration(new CategoriaTipoSolicitudETC());
            modelBuilder.ApplyConfiguration(new MaestroETC());
            modelBuilder.ApplyConfiguration(new BancoETC());
            modelBuilder.ApplyConfiguration(new RequisitoSolicitudETC());
            modelBuilder.ApplyConfiguration(new MovimientosETC());
            modelBuilder.ApplyConfiguration(new CambioETC());

        }

        public interface IAuditedEntity
        {
            string CreatedBy { get; set; }
            DateTime CreatedAt { get; set; }
            string LastModifiedBy { get; set; }
            DateTime LastModifiedAt { get; set; }
        }

        public override int SaveChanges()
        {
            var modifiedEntries = this.ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Modified)
                .Select(x => x.Entity)
                .ToList();

            foreach (var item in modifiedEntries)
            {
                DetectChanges(item);
            }

            var createdEntries = this.ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Added)
                .Select(x => x.Entity)
                .ToList();

            var deleted = this.ChangeTracker
                .Entries()
                .Where(x => x.State == EntityState.Deleted)
                .Select(x => x.Entity)
                .ToList();

            return base.SaveChanges();
        }

        private void DetectChanges(object item)
        {
            var type = item.GetType();
            var properties = type.GetProperties();

            var IdProperty = properties.Single(p => p.Name == "Id");            
            int id = Convert.ToInt32(IdProperty.GetValue(item)); 
            
        }
    }
}
