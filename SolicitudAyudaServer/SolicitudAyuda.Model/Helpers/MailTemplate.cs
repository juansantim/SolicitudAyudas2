namespace SolicitudAyuda.Model.Services.Signatures
{
    public static class MailTemplate
    {
        public static string CreacionSolicitud
        {
            get
            {
                return "notificacion.html";
            }
        }

        public static string CreacionUsuario
        {
            get
            {
                return "newAccount.html";
            }
        }

    }
}
