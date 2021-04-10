using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    public class ComentarioSolicitud
    {
        public int Id { get; set; }
        public string Comentario { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int SolicitudAyudaId { get; set; }
        public SolicitudAyuda SolicitudAyuda { get; set; }
    }
}
