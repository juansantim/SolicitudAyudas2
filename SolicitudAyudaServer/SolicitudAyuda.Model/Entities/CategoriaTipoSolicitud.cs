using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    public class CategoriaTipoSolicitud
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<TipoSolicitud> TiposSolicitudes { get; set; }
    }
}
