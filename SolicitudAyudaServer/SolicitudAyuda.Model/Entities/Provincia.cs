using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("Provincias")]
    public class Provincia
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Municipio> Municipios { get; set; }
    }
}
