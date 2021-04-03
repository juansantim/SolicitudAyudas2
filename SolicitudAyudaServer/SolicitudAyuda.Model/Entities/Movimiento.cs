using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    public class Movimiento
    {
        public int Id { get; set; }
        public string Entidad { get; set; }
        public string Key { get; set; }
        public DateTime Fecha { get; set; }
        public string Comentario { get; set; }
        public int UsuarioId { get; set; }
        public List<Cambio> Cambios { get; set; }

        public Movimiento()
        {
            Cambios = new List<Cambio>();
            Fecha = DateTime.Now;
        }
    }
}
