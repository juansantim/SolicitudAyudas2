using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class ComisionAprobacionUsuarioDTO
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int UsuarioId { get; set; }
        public int UsuarioCreacionId { get; set; }
        public int ComisionAprobacionId { get; set; }
        public bool Checked { get; set; }
    }
}
