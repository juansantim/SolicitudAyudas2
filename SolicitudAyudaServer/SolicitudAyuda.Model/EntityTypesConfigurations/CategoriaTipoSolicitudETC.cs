using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class CategoriaTipoSolicitudETC : IEntityTypeConfiguration<CategoriaTipoSolicitud>
    {
        public void Configure(EntityTypeBuilder<CategoriaTipoSolicitud> entity)
        {
            entity.ToTable("CategoriasTiposSolicitudes");

            entity.HasMany(e => e.TiposSolicitudes).WithOne(cat => cat.Categoria).HasForeignKey(e => e.CategoriaId).OnDelete(DeleteBehavior.NoAction);

            entity.HasData(new CategoriaTipoSolicitud 
            {
                Id = 1,
                Nombre = "Ayudas de Salud"
            });

            entity.HasData(new CategoriaTipoSolicitud
            {
                Id = 2,
                Nombre = "Ayudas de Infraestructura y Construcción"
            });

            entity.HasData(new CategoriaTipoSolicitud
            {
                Id = 3,
                Nombre = "Otros"
            });
        }
    }
}
