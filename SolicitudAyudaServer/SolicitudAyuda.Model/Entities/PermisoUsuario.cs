using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    public class PermisoUsuario
    {
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int PermisoId { get; set; }
        public virtual Permiso Permiso { get; set; }

        public bool Disponible { get; set; }
    }
}
