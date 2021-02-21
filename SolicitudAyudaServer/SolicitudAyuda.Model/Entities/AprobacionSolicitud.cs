using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    public class AprobacionSolicitud
    {
        public int Id { get; set; }
        public int SolicitudAyudaId { get; set; }
        
        public SolicitudAyuda SolicitudAyuda { get; set; }

        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        
        public DateTime? FechaAprobacion { get; set; }
    }
}
