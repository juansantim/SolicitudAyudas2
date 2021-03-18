using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class ActivacionUsuarioDTO
    {
        public int UsuarioId { get; set; }
        public string NombreCompleto { get; set; }
        public string Email { get; set; }
        public string Seccional { get; set; }
        public string Password1 { get; set; }
        public string Password2 { get; set; }
    }
}
