using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class ProcesarSolicitudDTO
    {
        public int solicitudId { get; set; }
        public int estadoId { get; set; } 
        public string comentario { get; set; }
    }
}
