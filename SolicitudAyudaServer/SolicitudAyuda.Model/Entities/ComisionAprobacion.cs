using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    public class ComisionAprobacion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<UsuarioComisionAprobacion> UsuariosComisionAprobacion { get; set; }

        public List<TipoSolicitud> TiposSolicitudes { get; set; }

        public ComisionAprobacion()
        {
            UsuariosComisionAprobacion = new List<UsuarioComisionAprobacion>();
            TiposSolicitudes = new List<TipoSolicitud>();
        }
    }
}
