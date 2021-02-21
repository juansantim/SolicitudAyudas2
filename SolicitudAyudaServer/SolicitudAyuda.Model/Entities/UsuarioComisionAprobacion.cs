using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    public class UsuarioComisionAprobacion
    {
        public int Id { get; set; }
        public int ComisionAprobacionId { get; set; }
        public ComisionAprobacion ComisionAprobacion { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }
        public bool Disponible { get; set; }
        public DateTime FechaCreacion { get; set; }
        public int UsuarioCreacionId { get; set; }

    }
}
