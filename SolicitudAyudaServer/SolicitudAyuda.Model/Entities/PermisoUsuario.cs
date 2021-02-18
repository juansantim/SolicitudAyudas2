using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    public class PermisoUsuario
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public bool Disponible { get; set; }
    }
}
