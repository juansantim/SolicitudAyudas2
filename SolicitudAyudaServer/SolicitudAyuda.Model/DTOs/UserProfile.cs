﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.DTOs
{
    public class UserProfile
    {
        public string Email { get; set; }
        public string NombreCompleto { get; set; }        
        public string Seccional { get; set; }
        public string Token { get; set; }
    }
}
