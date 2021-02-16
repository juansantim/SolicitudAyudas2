using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class FiltroSolicitudesDTO                                         
    {
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }

        public string cedula { get; set; }
        public int? seccionalId { get; set; }
        public DateTime? solicitudDesde { get; set; }
        public DateTime? solicitudHasta { get; set; }
        public DateTime? aprobacionDesde { get; set; }
        public DateTime? aprobacionHasta { get; set; }

    }
}
