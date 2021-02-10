using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("Usuarios")]
    public class Usuario
    {
        public int Id { get; set; }
        public string Login { get; set; }

        public string Password { get; set; }

        public bool DebeCambiarPassword { get; set; }

        public string TempPassword { get; set; }

        public bool Disponible { get; set; }

        public DateTime? FechaCreacion { get; set; }

        public DateTime? FechaInactivacion { get; set; }

        public int? UsuarioIdInactivacion { get; set; }

        public List<SolicitudAyuda> SolicitudesAyuda { get; set; }
    }
}
