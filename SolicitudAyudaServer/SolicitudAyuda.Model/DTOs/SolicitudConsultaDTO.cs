using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class SolicitudConsultaDTO
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string Seccional { get; set; }
        public string TipoSolicitud { get; set; }
        public string Solicitante { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal MontoAprobado { get; set; }
        public string Estado { get; set; }
        public int EstadoId { get; set; }
        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaAprobacion { get; set; }
        public override bool Equals(object obj)
        {
            return this.Id == (obj as SolicitudConsultaDTO).Id;
        }
    }
}
