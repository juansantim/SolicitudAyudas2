using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("TiposSolicitudes")]
    public class TipoSolicitud
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<RequisitoTipoSolicitud> Requisitos { get; set; }
        public List<SolicitudAyuda> Solicitudes { get; set; }
        public int ComisionAprobacionId { get; set; }
        public ComisionAprobacion ComisionAprobacion { get; set; }
        public int CategoriaId { get; set; }
        public CategoriaTipoSolicitud Categoria { get; set; }
    }
}
