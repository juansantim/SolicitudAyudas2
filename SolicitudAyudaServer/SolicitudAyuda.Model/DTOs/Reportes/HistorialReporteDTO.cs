using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs.Reportes
{
    public class HistorialReporteDTO
    {
        public int NumeroSolicitud { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public string TipoSolicitud { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal MontoAprobado { get; set; }
        public string Estado { get; set; }

    }
}
