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

namespace SolicitudAyudaServer.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class ReportesController : ControllerBase
    {
        private readonly IConfiguration config;
        private readonly DataContext db;

        public ReportesController(IConfiguration config, DataContext db)
        {
            this.config = config;
            this.db = db;
        }

        public FileResult get()
        {
            //string reportUrl = $"{config["ReportsUrl"]}HistorialAfiliado.frx";

            //var dataSet = GetData();

            //WebReport webReport = new WebReport();
            //webReport.Report.Load(reportUrl);

            //webReport.Report.RegisterData(dataSet, "Data", true);

            //var dataBand = (DataBand)webReport.Report.FindObject("Data1");            
            //dataBand.DataSource = webReport.Report.GetDataSource("Data");

            //webReport.Report.Prepare();

            //using (MemoryStream ms = new MemoryStream())
            //{

            //    PDFSimpleExport pdfExport = new PDFSimpleExport();
            //    pdfExport.Export(webReport.Report, ms);
            //    ms.Flush();

            //    return File(ms.ToArray(), "application/pdf","reporte.pdf");
            //}

            string path = @"C:\workspace\adp\SolicitudAyudaServer\ReportsProject\Report.rdlc";

            var dt = GetDataTable();
            string mimetype = "";
            int extension = 1;
            Dictionary<string, string> parameters = new Dictionary<string, string>();
            //parameters.Add("prm", "RDLC report (Set as parameter)");
            LocalReport lr = new LocalReport(path);

            lr.AddDataSource("DataSet", dt);
            var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);
            return File(result.MainStream, "application/pdf");

        }

        private DataTable GetDataTable() 
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("Numero", typeof(string));
            dt.Columns.Add("Solicitante", typeof(string));
            dt.Columns.Add("Monto", typeof(decimal));

            var solicitudes = db.Solicitudes.Include(s => s.Maestro).ToList();

            foreach (var item in solicitudes)
            {
                var row = dt.NewRow();
                row["Numero"] = item.NumeroExpediente;
                row["Solicitante"] = item.Maestro.NombreCompleto;
                row["Monto"] = item.MontoSolicitado;

                dt.Rows.Add(row);
            }

            return dt;
        }

        private DataSet GetData() 
        {
            var solicitudes = db.Solicitudes.Take(100)
              .Include(s => s.Estado)
              .Include(s => s.Maestro)
              .Include(s => s.TipoSolicitud)
              .Select(s => new HistorialReporteDTO
              {
                  NumeroSolicitud = s.NumeroExpediente,
                  Estado = s.Estado.Nombre,
                  FechaSolicitud = s.FechaSolicitud,
                  MontoSolicitado = s.MontoSolicitado,
                  MontoAprobado = s.MontoAprobado ?? 0,
                  TipoSolicitud = s.TipoSolicitud.Nombre

              });

            var dataSet = new DataSet();
            var table = new DataTable("Data");
            table.Columns.Add(new DataColumn("NumeroSolicitud", typeof(int)));
            table.Columns.Add(new DataColumn("Estado", typeof(string)));
            table.Columns.Add(new DataColumn("FechaSolicitud", typeof(DateTime)));
            table.Columns.Add(new DataColumn("MontoSolicitado", typeof(decimal)));
            table.Columns.Add(new DataColumn("MontoAprobado", typeof(decimal)));
            table.Columns.Add(new DataColumn("TipoSolicitud", typeof(string)));

            foreach (var item in solicitudes)
            {
                var row = table.NewRow();
                row[0] = item.NumeroSolicitud;
                row[1] = item.Estado;
                row[2] = item.FechaSolicitud;
                row[3] = item.MontoSolicitado;
                row[4] = item.MontoAprobado;
                row[5] = item.TipoSolicitud;

                table.Rows.Add(row);
            }

            dataSet.Tables.Add(table);

            return dataSet;
        }

    }
}
