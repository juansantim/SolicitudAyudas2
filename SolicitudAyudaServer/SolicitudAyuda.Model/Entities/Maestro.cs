using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("Maestros")]
    public class Maestro
    {
        public int Id { get; set; }
        public string Cedula { get; set; }
        public string NombreCompleto { get; set; }
        public string Sexo { get; set; }
        public int? SeccionalId { get; set; }
        public Seccional Seccional { get; set; }
        public string Cargo { get; set; }

        public List<SolicitudAyuda> Solicitudes { get; set; }
    }
}
