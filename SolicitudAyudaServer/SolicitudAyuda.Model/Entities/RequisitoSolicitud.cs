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
        public string Nombre { get; set; }
        public bool Verificado { get; set; }

        public SolicitudAyuda SolicitudAyuda { get; set; }
    }
}
