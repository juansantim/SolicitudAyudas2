using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Services.Signatures
{
    public interface ISendEmailService
    {
        public void SendEmail(string body, string subject, string to);
        public string GetEmailTemplate(string baseUrl, string templateName);
    }
}
