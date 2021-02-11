using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class HttpResponse
    {
        public bool Success
        {
            get
            {
                return Errors.Count == 0;
            }
        }
        public dynamic Data { get; set; }
        public List<string> Errors { get; set; }

        public HttpResponse()
        {
            Errors = new List<string>();
        }

    }
}
