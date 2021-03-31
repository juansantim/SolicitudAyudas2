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
            entity.HasMany(p => p.PermisosUsuarios).WithOne(pu => pu.Permiso).HasForeignKey(pu => pu.PermisoId);

            var seed = new List<Permiso>
            {
                new Permiso{
                    Id  = 1,
                    Nombre = "Consultar Solicitudes",
                    Descripcion = "Entrar y consultar por diferentes criterios"
                },
                new Permiso{
                    Id  = 2,
                    Nombre = "Crear Solicitudes",
                    Descripcion = "Registrar una solicitud"
                },
                new Permiso{
                    Id  = 3,
                    Nombre = "Aprobar Solicitudes"
                },
                new Permiso{
                    Id  = 4,
                    Nombre = "Rechazar Solicitudes",
                    Descripcion = "Rechazar solicitud por cualquier motivo"

                },
                new Permiso{
                    Id  = 5,
                    Nombre = "Anular Solicitudes",
                    Descripcion = "Anular una solicitud, siempre y cuando no se encuentre aprobada"
                },
                new Permiso{
                    Id  = 6,
                    Nombre = "Ver record de Afiliado",
                    Descripcion ="Consultar informaciones de afiliado"
                },
                new Permiso{
                    Id  = 7 ,
                    Nombre = "Generar Estadísticas",
                    Descripcion = "Generar reportes"
                },
                new Permiso{
                    Id  = 8 ,
                    Nombre = "Gestionar Usuarios",
                    Descripcion = "Crear, modificar y deshabilitar usuarios"
                },
                new Permiso{
                    Id  = 9 ,
                    Nombre = "Modificar Solicitud",
                    Descripcion = "Modificar, monto solicitado, banco y numero de cuenta de la solicitud"
                }
            };

            entity.HasData(seed);
        }
    }
}
