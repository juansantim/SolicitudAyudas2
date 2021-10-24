using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("SubTipoSolicitudesAyuda")]
    public class SubTipoSolicitudAyuda
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string TiposSolicitudes { get; set; }

        public bool Disponible { get; set; }

        public List<SolicitudAyuda> SolicitudesAyudas { get; set; }
    }
}
