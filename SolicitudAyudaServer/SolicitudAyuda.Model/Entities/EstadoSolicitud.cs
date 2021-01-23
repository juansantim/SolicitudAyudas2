using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("EstadoSolicitudes")]
    public class EstadoSolicitud
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<SolicitudAyuda> SolicitudesAyuda  { get; set; }
    }
}
