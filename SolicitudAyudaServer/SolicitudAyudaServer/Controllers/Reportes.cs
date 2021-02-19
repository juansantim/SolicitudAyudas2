using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FastReport;
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
            string reportUrl = $"{config["ReportsUrl"]}HistorialAfiliado.frx";

            var dataSet = GetData();
            
            WebReport webReport = new WebReport();
            webReport.Report.Load(reportUrl);
           // webReport.Report.Dictionary.Clear();

            webReport.Report.RegisterData(dataSet, "Data", true);

            var dataBand = (DataBand)webReport.Report.FindObject("Data1");            
            dataBand.DataSource = webReport.Report.GetDataSource("Data");

            //webReport.Report.SetParameterValue()

            //var source = new FastReport.Data.TableDataSource();
            //source.Table = dataSet;
            //source.Name = "Data";

            //dataBand.DataSource = source;

            webReport.Report.Prepare();

            //dataBand.DataSource = webReport.Report.GetDataSource("Data");

            using (MemoryStream ms = new MemoryStream())
            {
                PDFSimpleExport pdfExport = new PDFSimpleExport();
                pdfExport.Export(webReport.Report, ms);
                ms.Flush();
                
                return File(ms.ToArray(), "application/pdf", Path.GetFileNameWithoutExtension("Master-Detail") + ".pdf");
            }


            
            //parameters.Add(new ReportParameter("Usuario", "juanv.santim"));
            //parameters.Add(new ReportParameter("Cedula", "xxxxxxxxxx"));
            //parameters.Add(new ReportParameter("NombreCompleto", "Juan Valentin Santi Mateo"));

            //report.SetParameters(parameters);
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
