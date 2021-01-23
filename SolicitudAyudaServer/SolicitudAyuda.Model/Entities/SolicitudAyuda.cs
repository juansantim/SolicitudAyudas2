using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("SolicitudesAyuda")]
    public class SolicitudAyuda
    {
        public int Id { get; set; }
        public int NumeroExpediente { get; set; }
        public string CedulaSolicitante { get; set; }
        public int MaestroId { get; set; }
        public string Telefono { get; set; }
        public string Email { get; set; }
        public Maestro Maestro { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public int TipoSolicitudId { get; set; }
        public TipoSolicitud TipoSolicitud { get; set; }
        public List<RequisitoSolicitud> Requisitos { get; set; }
        public List<AdjuntosSolicitud> Adjuntos { get; set; }
        public int ARSId { get; set; }
        public ARS ARS { get; set; }
        public string Concepto { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal? MontoAprobado { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int EstadId { get; set; }
        public EstadoSolicitud Estado { get; set; }
    }
}
