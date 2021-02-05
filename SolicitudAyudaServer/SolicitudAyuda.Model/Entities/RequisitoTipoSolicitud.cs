using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("RequisitosTiposSolicitud")]
    public class RequisitoTipoSolicitud
    {
        public int Id { get; set; }
        public int TipoSolicitudId { get; set; }
        public string FormName { get; set; }
        public TipoSolicitud TipoSolicitud { get; set; }
        public string Descripcion { get; set; }
        public string PossibleValues { get; set; }
    }
}
