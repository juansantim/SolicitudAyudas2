using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class PaginatedResult<T>
    {
        public int TotalItems { get; set; }
        public List<T> Data { get; set; }
    }
}
