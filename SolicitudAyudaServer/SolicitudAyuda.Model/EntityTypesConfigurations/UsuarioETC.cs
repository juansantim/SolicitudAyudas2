﻿using Microsoft.EntityFrameworkCore;
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

            entity.Property(us => us.Email).HasMaxLength(100);

        }
    }
}