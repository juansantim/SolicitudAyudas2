using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("Permisos")]
    public class Permiso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public List<PermisoUsuario> PermisosUsuarios { get; set; }
        public Permiso()
        {
            PermisosUsuarios = new List<PermisoUsuario>();
        }

    }
}
