using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class FiltroDataUsuarioDTO
    {
        public int ItemsPerPage { get; set; }
        public int Page { get; set; }
        public string SearchText { get; set; }
    }
}
