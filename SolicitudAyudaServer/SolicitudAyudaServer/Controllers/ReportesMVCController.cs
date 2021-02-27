using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FastReport.Data;
using FastReport.Utils;
using FastReport.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace SolicitudAyudaServer.Controllers
{
    public class ReportesMVCController : Controller
    {
        private readonly IConfiguration config;
        public ReportesMVCController(IConfiguration config)
        {
            this.config = config;
        }
        public IActionResult Index()
        {
            var webReport = new WebReport();

            RegisteredObjects.AddConnection(typeof(MsSqlDataConnection));

            MsSqlDataConnection sqlConnection = new MsSqlDataConnection();
            sqlConnection.Name = "Connection";
            sqlConnection.ConnectionString = config.GetConnectionString("adp");

            sqlConnection.CreateAllTables();
            webReport.Report.Dictionary.Connections.Add(sqlConnection);
            webReport.Report.Load(@"C:\workspace\adp\SolicitudAyudaServer\SolicitudAyudaServer\Reports\ReporteSolicitudes.frx");


            return View(webReport);
        }
    }
}
