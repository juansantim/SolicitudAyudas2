using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class HttpDataResponse
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

        public void AddError(string error)
        {
            this.Errors.Add(error);
        }

        public HttpDataResponse()
        {
            Errors = new List<string>();
        }

    }
}
