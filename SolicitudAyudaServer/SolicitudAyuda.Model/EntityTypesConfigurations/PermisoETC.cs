using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class PermisoETC : IEntityTypeConfiguration<Permiso>
    {
        public void Configure(EntityTypeBuilder<Permiso> entity)
        {
            entity.Property(e => e.Nombre).HasMaxLength(100);

            var seed = new List<Permiso>
            {
                new Permiso{
                    Id  = 1,
                    Nombre = "Consultar Solicitudes"
                },
                new Permiso{
                    Id  = 2,
                    Nombre = "Crear Solicitudes"
                },
                new Permiso{
                    Id  = 3,
                    Nombre = "Aprobar Solicitudes"
                },
                new Permiso{
                    Id  = 4,
                    Nombre = "Rechazar Solicitudes"
                },
                new Permiso{
                    Id  = 5,
                    Nombre = "Anular Solicitudes"
                },
                new Permiso{
                    Id  = 6,
                    Nombre = "Ver record de Afiliado"
                },
                new Permiso{
                    Id  = 7 ,
                    Nombre = "Generar Estadísticas"
                }


            };

            entity.HasData(seed);
        }
    }
}
