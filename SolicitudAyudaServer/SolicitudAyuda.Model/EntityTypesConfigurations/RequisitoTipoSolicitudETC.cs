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
            entity.Property(e => e.Descripcion).HasMaxLength(255);

            entity.Property(e => e.PossibleValues).HasColumnName("PossibleValues");
            entity.Property(e => e.PossibleValues).HasMaxLength(4000);

            //entity.HasMany(rt => rt.RequisitosSolicitudes)
            //    .WithOne(rs => rs.RequisitoTipoSolicitud)
            //    .HasForeignKey(rs => rs.RequisitoTiposSolicitudId)
            //    .OnDelete(DeleteBehavior.NoAction);

            entity.HasData(new List<RequisitoTipoSolicitud>()
            {
                new RequisitoTipoSolicitud {Id = 1, FormName="rdcomunicacion", TipoSolicitudId = 1, Descripcion = "Comunicacion solicitud del interesado dirigida al CEN", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 2, FormName="rdcopiacedula", TipoSolicitudId = 1, Descripcion = "Copia de cedula", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 3, FormName="rdexpendiente", TipoSolicitudId = 1, Descripcion = "Expediente clinico que demuestre diagnostico actualizado", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 4, FormName="rdcartaaval", TipoSolicitudId = 1, Descripcion = "Carta aval de la seccional a la que pertenece", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 5, FormName="rdars", TipoSolicitudId = 1, Descripcion = "ARS a que pertenece", PossibleValues = "ARS CMD,ARS APS,ARS SIMAG,ARS GRUPO MEDICO ASOCIADO,ARS YUNEN,ARS UNIVERSAL,ARS MONUMENTAL,ARS FUTURO,ARS PRIMERA,ARS ASEMAP,ARS SEMMA,ARS RENACER,ARS PALIC-SALUD,ARS PLAN SALUD,ARS SENASA,ARS RESERVAS,ARS METASALUD,ARS SENASA - REGIMEN SUBSIDIADO" },


                new RequisitoTipoSolicitud {Id = 6, FormName="rdcomunicacion", TipoSolicitudId = 2, Descripcion = "Comunicacion solicitud del interesado dirigida al CEN", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 7, FormName="rdcopiacedula", TipoSolicitudId = 2, Descripcion = "Copia de cedula", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 8, FormName="rdexpendiente", TipoSolicitudId = 2, Descripcion = "Expediente clinico que demuestre diagnostico actualizado", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 9, FormName="rdcartaaval", TipoSolicitudId = 2, Descripcion = "Carta aval de la seccional a la que pertenece", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 10, FormName="rdars", TipoSolicitudId = 2, Descripcion = "ARS a que pertenece", PossibleValues = "ARS CMD,ARS APS,ARS SIMAG,ARS GRUPO MEDICO ASOCIADO,ARS YUNEN,ARS UNIVERSAL,ARS MONUMENTAL,ARS FUTURO,ARS PRIMERA,ARS ASEMAP,ARS SEMMA,ARS RENACER,ARS PALIC-SALUD,ARS PLAN SALUD,ARS SENASA,ARS RESERVAS,ARS METASALUD,ARS SENASA - REGIMEN SUBSIDIADO" },

                new RequisitoTipoSolicitud {Id = 11, FormName="rdcomunicacion", TipoSolicitudId = 3, Descripcion = "Comunicacion solicitud del interesado dirigida al CEN", PossibleValues = "" },
                new RequisitoTipoSolicitud {Id = 12, FormName="rdcopiacedula", TipoSolicitudId = 3, Descripcion = "Copia de cedula", PossibleValues = "" },                        
                new RequisitoTipoSolicitud {Id = 13, FormName="rdcartaaval", TipoSolicitudId = 3, Descripcion = "Carta aval de la seccional a la que pertenece", PossibleValues = "" },
            });

        }
    }
}
