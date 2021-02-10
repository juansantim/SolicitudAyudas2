using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("AdjuntosSolicitudesAyuda")]
    public class AdjuntosSolicitud
    {
        public int Id { get; set; }
        public int SolicitudAyudaId { get; set; }
        public SolicitudAyuda SolicitudAyuda { get; set; }        
        public string DisplayName { get; set; }
        public string URL { get; set; }
        public decimal SizeMB { get; set; }
    }
}
