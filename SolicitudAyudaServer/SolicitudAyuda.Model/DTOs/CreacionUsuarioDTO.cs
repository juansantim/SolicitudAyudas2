using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class CreacionUsuarioDTO
    {
        public string Login { get; set; }
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public int SeccionalId { get; set; }
        public string Email { get; set; }
        public string Direccion { get; set; }
        public string TelefonoLabora { get; set; }
        public string TelefonoCelular { get; set; }
        public string TelefonoResidencial { get; set; }
        public string Sexo { get; set; }
        public DateTime FechaNacimiento { get; set; }

        public string Host { get; set; }

        public List<PermisosUsuarioDTO> PermisosUsuario { get; set; }
        public string Cargo { get; set; }
    }
}
