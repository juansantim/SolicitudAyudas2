using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AspNetCore.Reporting;
using FastReport;
using FastReport.Export.Html;
using FastReport.Export.PdfSimple;
using FastReport.Web;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SolicitudAyuda.Model;
using SolicitudAyuda.Model.DTOs.Reportes;
using SolicitudAyuda.Model.DTOs.Reportes.Filtros;
using SolicitudAyuda.Model.Services.Signatures;

namespace SolicitudAyudaServer.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IReportesService service;

        public ReportesController(IConfiguration config, DataContext db, IReportesService service)
        {
            this.service = service;
        }

        [Route("ResumenSolicitudesPorSeccional")]
        public FileResult ResumenSolicitudesPorSeccional(FiltroSolicitudesPorSeccional filtro) 
        {
            var bytes = this.service.ResumenSolicitudesPorSeccional(filtro.desde, filtro.hasta, filtro.seccionalId);

            return File(bytes, "application/pdf", true);
        }

        [Route("ResumenSolicitudesAprobadasPorSeccional")]
        public FileResult ResumenSolicitudesAprobadasPorSeccional(FiltroSolicitudesPorSeccional filtro)
        {
            var bytes = this.service.ResumenSolicitudesPorSeccional(filtro.desde, filtro.hasta, filtro.seccionalId);

            return File(bytes, "application/pdf", true);
        }

    }
}
