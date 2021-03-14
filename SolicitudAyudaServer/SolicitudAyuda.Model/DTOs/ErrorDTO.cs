using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public struct ErrorDTO
    {
        public int Code { get; set; }
        public string Message { get; set; }
    }
}

/*
 * 1 - Afiliado ya ha solicitado antes del tiempo reglamentario
 * 2 - Afiliado ya tiene una solicitud registrada el dia de hoy
 */
