using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("ARS")]
    public class ARS
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
    }
}
