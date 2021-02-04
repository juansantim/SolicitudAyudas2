using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.EntityTypesConfigurations
{
    public class RequisitoTipoSolicitudETC : IEntityTypeConfiguration<RequisitoTipoSolicitud>
    {
        public void Configure(EntityTypeBuilder<RequisitoTipoSolicitud> entity)
        {
            entity.Property(e => e.Nombre).HasMaxLength(255);

            entity.Property(e => e.PossibleValues).HasColumnName("PossibleValues");
            entity.Property(e => e.PossibleValues).HasMaxLength(4000);

            entity.HasData(new List<RequisitoTipoSolicitud>()
            {
                new RequisitoTipoSolicitud {Id = 1, TipoSolicitudId = 1, Nombre = "Comunicacion solicitud del interesado dirigida al CEN", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 2, TipoSolicitudId = 1, Nombre = "Copia de cedula", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 3, TipoSolicitudId = 1, Nombre = "Expediente clinico que demuestre diagnostico actualizado", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 4, TipoSolicitudId = 1, Nombre = "Carta aval de la seccional a la que pertenece", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 5, TipoSolicitudId = 1, Nombre = "ARS a que pertenece", PossibleValues = "ARS CMD,ARS APS,ARS SIMAG,ARS GRUPO MEDICO ASOCIADO,ARS YUNEN,ARS UNIVERSAL,ARS MONUMENTAL,ARS FUTURO,ARS PRIMERA,ARS ASEMAP,ARS SEMMA,ARS RENACER,ARS PALIC-SALUD,ARS PLAN SALUD,ARS SENASA,ARS RESERVAS,ARS METASALUD,ARS SENASA - REGIMEN SUBSIDIADO" },
                new RequisitoTipoSolicitud {Id = 6, TipoSolicitudId = 2, Nombre = "Comunicacion solicitud del interesado dirigida al CEN", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 7, TipoSolicitudId = 2, Nombre = "Copia de cedula", PossibleValues = "" },                        
                new RequisitoTipoSolicitud {Id = 8, TipoSolicitudId = 2, Nombre = "Carta aval de la seccional a la que pertenece", PossibleValues = "" },
            });

        }
    }
}
