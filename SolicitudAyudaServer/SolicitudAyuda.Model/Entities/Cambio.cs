using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    public class Cambio
    {
        public int Id { get; set; }
        public int MovimientoId { get; set; }
        public Movimiento Movimiento { get; set; }
        public string Propiedad { get; set; }
        public string Antes { get; set; }
        public string Despues { get; set; }

    }
}
