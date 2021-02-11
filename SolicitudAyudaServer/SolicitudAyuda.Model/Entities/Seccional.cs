using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("Seccionales")]
    public class Seccional
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public int MunicipioId { get; set; }
        public Municipio Municipio { get; set; }
        public int? PresidenteId { get; set; }
        public List<Maestro> Maestros { get; set; }
        public List<SolicitudAyuda> SolicitudesAyuda { get; set; }

        public Seccional()
        {
            SolicitudesAyuda = new List<SolicitudAyuda>();
        }
    }
}
