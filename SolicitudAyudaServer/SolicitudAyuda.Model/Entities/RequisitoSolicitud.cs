using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("RequisitosSolicitudes")]
    public class RequisitoSolicitud
    {
        public int Id { get; set; }
        public int SolicitudAyudaId { get; set; }
        public SolicitudAyuda SolicitudAyuda { get; set; }
        public int RequisitoTiposSolicitudId { get; set; }
        public virtual RequisitoTipoSolicitud RequisitoTipoSolicitud { get; set; }
        public string Value { get; set; }
    }
}
