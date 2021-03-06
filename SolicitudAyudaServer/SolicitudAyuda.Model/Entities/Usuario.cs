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
        public string NombreCompleto { get; set; }
        public string Login { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }        
        public string ChangePasswordCode { get; set; }
        /// <summary>
        /// Dar 1 hora de validez para este código
        /// </summary>
        public DateTime? ChangePasswordCodeExpiration { get; set; }
        public bool Disponible { get; set; }
        public DateTime? FechaCreacion { get; set; }
        public DateTime? FechaInactivacion { get; set; }
        public int? UsuarioIdInactivacion { get; set; }
        public int? MaestroId { get; set; }
        public Maestro Maestro { get; set; }

        public List<SolicitudAyuda> SolicitudesAyuda { get; set; }
        public List<PermisoUsuario> PermisosUsuario { get; set; }
        public List<UsuarioComisionAprobacion> UsuariosComisionesAprobacion { get; set; }
        public List<AprobacionSolicitud> AprobacionesSolicitudes { get; set; }
        public int SeccionalId { get; set; }
        public Seccional Seccional { get; set; }
    }
}
