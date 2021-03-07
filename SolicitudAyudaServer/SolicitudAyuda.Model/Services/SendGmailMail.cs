using Microsoft.Extensions.Configuration;
using SolicitudAyuda.Model.Services.Signatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading;

namespace SolicitudAyuda.Model.Services
{
    public class SendGmailMail: ISendEmailService
    {
        private readonly IConfiguration config;

        public SendGmailMail(IConfiguration config)
        {
            this.config = config;
        }
        public string GetEmailTemplate(string baseUrl, string templateName)
        {
            var templatesUrl = $"{baseUrl}{Path.DirectorySeparatorChar}EmailTemplates{Path.DirectorySeparatorChar}{templateName}";

            return System.IO.File.ReadAllText(templatesUrl);
        }

        public void SendEmail(string body, string subject, string to)
        {
            
            var fromAddress = new MailAddress("notificacionesadp1@gmail.com", "Asiciación Dominicana de Profesores");
            var toAddress = new MailAddress(to, to);

            const string fromPassword = "AdpNotificaciones1914";

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword)
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                IsBodyHtml = true,
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }

        }
    }
}
