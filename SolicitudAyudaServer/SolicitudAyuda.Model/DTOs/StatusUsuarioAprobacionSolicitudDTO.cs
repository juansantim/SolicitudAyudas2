using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class StatusUsuarioAprobacionSolicitudDTO
    {
        public string Usuario { get; set; }        
        public string Estado { get; set; }
        public int EstadoId { get; set; }
        public DateTime? Fecha { get; set; }

        public string Comentario { get; set; }
    }
}
