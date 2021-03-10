using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using SolicitudAyuda.Model.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class UsuarioETC : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> entity)
        {
            entity.Property(u => u.Login).HasMaxLength(40);
            entity.Property(u => u.NombreCompleto).HasMaxLength(100);
            entity.Property(u => u.Password).HasMaxLength(40);
            entity.Property(u => u.TempPassword).HasMaxLength(10);
            
            entity.HasMany(u => u.PermisosUsuario).WithOne(PermisoUsuario => PermisoUsuario.Usuario).HasForeignKey(pu => pu.UsuarioId);
            entity.HasMany(u => u.UsuariosComisionesAprobacion).WithOne(uc => uc.Usuario).HasForeignKey(uc => uc.UsuarioId).OnDelete(DeleteBehavior.NoAction); 
            
            
            entity.HasData(new Usuario 
            {
                Id = 1,
                Login = "Sistema",
                Email = "",
                NombreCompleto = "El Sistema",
                Disponible = false,
                FechaCreacion = DateTime.Now,
                DebeCambiarPassword = false,
                Password = "",
            });

            entity.HasData(new Usuario
            {
                Id = 2,
                Login = "jsanti",
                Email = "juanv.santim@gmail.com",
                NombreCompleto = "Juan Santi",
                Disponible = true,
                FechaCreacion = DateTime.Now,
                DebeCambiarPassword = false,
                Password = MD5Helper.MD5Hash("14021989"),
            });

            entity.HasData(new Usuario
            {
                Id = 3,
                Login = "miembro1",
                Email = "miembro1@gmail.com",
                NombreCompleto = "miembro comision 1",
                Disponible = true,
                FechaCreacion = DateTime.Now,
                DebeCambiarPassword = false,
                Password = MD5Helper.MD5Hash("14021989"),
            });

            entity.HasData(new Usuario
            {
                Id = 4,
                Login = "miembro2",
                Email = "miembro2@gmail.com",
                NombreCompleto = "miembro comision 2",
                Disponible = true,
                FechaCreacion = DateTime.Now,
                DebeCambiarPassword = false,
                Password = MD5Helper.MD5Hash("14021989"),
            });

            entity.HasData(new Usuario
            {
                Id = 5,
                Login = "miembro3",
                Email = "miembro3@gmail.com",
                NombreCompleto = "miembro comision 3",
                Disponible = true,
                FechaCreacion = DateTime.Now,
                DebeCambiarPassword = false,
                Password = MD5Helper.MD5Hash("14021989"),
            });


            entity.Property(us => us.Email).HasMaxLength(100);

        }
    }
}
