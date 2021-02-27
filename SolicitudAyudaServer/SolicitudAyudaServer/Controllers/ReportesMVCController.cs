using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastReport.Data;
using FastReport.Utils;
using FastReport.Web;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SolicitudAyudaServer.Controllers
{
    public class ReportesMVCController : Controller
    {
        private readonly IConfiguration config;
        private readonly IHostingEnvironment environment;
        private string BaseReportUrl;

        public ReportesMVCController(IConfiguration config, IHostingEnvironment environment)
        {
            this.config = config;
            this.environment = environment;
            this.BaseReportUrl = $"{environment.ContentRootPath}{System.IO.Path.DirectorySeparatorChar}Reports";
        }

        public string GetReportPath(string reportName)
        {
            return $"{BaseReportUrl}{System.IO.Path.DirectorySeparatorChar}{reportName}";
        }

        public IActionResult Index()
        {
            var webReport = new WebReport();

            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

            var reportPath = GetReportPath("ReporteSolicitudes.frx");

            webReport.Report.Load(reportPath);

            MsSqlDataConnection sqlConnection = (MsSqlDataConnection)webReport.Report.Dictionary.Connections[0];            
            sqlConnection.ConnectionString = config.GetConnectionString("adp");

            webReport.Report.SetParameterValue("SeccionalId", 0);

            webReport.Report.SetParameterValue("Seccional", "Todas");
            webReport.Report.SetParameterValue("Desde", new DateTime(2021, 1, 1));
            webReport.Report.SetParameterValue("Hasta", DateTime.Now);

            return View(webReport);
        }
    }
}

