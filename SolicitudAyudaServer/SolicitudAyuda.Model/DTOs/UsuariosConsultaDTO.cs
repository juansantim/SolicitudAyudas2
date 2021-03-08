using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class UsuariosConsultaDTO
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string NombreCompleto { get; set; }
        public bool Disponible { get; set; }
        public string Seccional { get; set; }
        public int SeccionalId { get; set; }

        public List<string> Permisos { get; set; }
    }
}
