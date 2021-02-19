using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class PermisoUsuarioETC : IEntityTypeConfiguration<PermisoUsuario>
    {
        public void Configure(EntityTypeBuilder<PermisoUsuario> entity)
        {
            entity.ToTable("PermisosUsuarios");

            entity.HasData(new PermisoUsuario 
            {
                Id = 1,
                PermisoId = 1,
                UsuarioId = 1,
                Disponible = true
            });

            entity.HasData(new PermisoUsuario
            {
                Id = 2,
                PermisoId = 2,
                UsuarioId = 1,
                Disponible = true
            });

            entity.HasData(new PermisoUsuario
            {
                Id = 3,
                PermisoId = 3,
                UsuarioId = 1,
                Disponible = true
            });

            entity.HasData(new PermisoUsuario
            {
                Id = 4,
                PermisoId = 4,
                UsuarioId = 1,
                Disponible = true
            });

            entity.HasData(new PermisoUsuario
            {
                Id = 5,
                PermisoId = 5,
                UsuarioId = 1,
                Disponible = true
            });

            entity.HasData(new PermisoUsuario
            {
                Id = 6,
                PermisoId = 6,
                UsuarioId = 1,
                Disponible = true
            });

            entity.HasData(new PermisoUsuario
            {
                Id = 7,
                PermisoId = 7,
                UsuarioId = 1,
                Disponible = true
            });
        }
    }
}
