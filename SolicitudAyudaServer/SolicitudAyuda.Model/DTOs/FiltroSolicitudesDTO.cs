using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class FiltroSolicitudesDTO                                         
    {
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }

        public string Cedula { get; set; }
        public int? SeccionalId { get; set; }
        public DateTime? SolicitudDesde { get; set; }
        public DateTime? SolicitudHasta { get; set; }
        public DateTime? AprobacionDesde { get; set; }
        public DateTime? AprobacionHasta { get; set; }

    }
}
