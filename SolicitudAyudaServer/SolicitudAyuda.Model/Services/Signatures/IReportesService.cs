using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Services.Signatures
{
    public interface IReportesService
    {
        byte[] ResumenSolicitudesPorSeccional(DateTime desde, DateTime hasta, int? seccionalId);
        byte[] ResumenSolicitudesAprobadasPorSeccional(DateTime desde, DateTime hasta, int? seccionalId);
    }
}
