using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class FileDataDTO
    {
        public string FileName { get; set; }
        public string OriginalFileName { get; set; }
        public Stream Content { get; set; }
        public string ContenType { get; set; }
    }
}
