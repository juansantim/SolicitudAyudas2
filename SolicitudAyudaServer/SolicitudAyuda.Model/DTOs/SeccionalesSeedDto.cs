using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class SeccionalesSeedDto
    {
        public int Id { get; set; }
        public string Provincia { get; set; }
        public string Municipio { get; set; }
        public string NOMBRE_Y_APELLIDOS { get; set; }        
        public string FLOTA { get; set; }
        public string Personal { get; set; }
        public int MunicipioId { get; set; }
    }
}
