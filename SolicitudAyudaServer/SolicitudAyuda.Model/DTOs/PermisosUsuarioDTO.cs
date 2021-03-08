using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class PermisosUsuarioDTO
    {
        public int Id { get; set; }

        public int PermisoId { get; set; }
        public string Permiso { get; set; }

        public bool Disponible { get; set; }
    }
}
