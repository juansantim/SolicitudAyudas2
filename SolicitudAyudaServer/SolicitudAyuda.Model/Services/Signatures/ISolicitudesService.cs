using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Services.Signatures
{
    public interface ISolicitudesService
    {
        dynamic GetDetalleSolicitud(int solicitudId);
    }
}
