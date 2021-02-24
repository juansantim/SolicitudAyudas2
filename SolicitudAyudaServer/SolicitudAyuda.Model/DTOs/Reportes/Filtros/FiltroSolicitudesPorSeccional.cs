using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs.Reportes.Filtros
{
    public class FiltroSolicitudesPorSeccional
    {
        public DateTime desde { get; set; }
        public DateTime hasta { get; set; }
        public int? seccionalId { get; set; }
    }
}
