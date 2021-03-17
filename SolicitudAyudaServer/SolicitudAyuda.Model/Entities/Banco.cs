using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    public class Banco
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public List<SolicitudAyuda> SolicitudesAyuda { get; set; }

        public Banco()
        {
            SolicitudesAyuda = new List<SolicitudAyuda>();
        }
    }
}
