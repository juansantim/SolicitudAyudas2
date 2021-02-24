using AspNetCore.Reporting;
using Microsoft.Extensions.Configuration;
using SolicitudAyuda.Model.Services.Signatures;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace SolicitudAyuda.Model.Services
{
    public class ReportesServiceMicrosoftReporting : IReportesService
    {
        private readonly DataContext db;
        string connectionString;
        private string BaseReportUrl;

        public ReportesServiceMicrosoftReporting(DataContext db, IConfiguration config)
        {
            this.db = db;
            this.connectionString = config.GetConnectionString("adp");
            this.BaseReportUrl = config["ReportsUrl"];
        }

        public string GetReportPath(string reportName)
        {
            return $"{BaseReportUrl}\\{reportName}";
        }

        public byte[] ResumenSolicitudesAprobadasPorSeccional(DateTime desde, DateTime hasta, int? seccionalId)
        {
            var data = GetResumenSolicitudesAprobadasPorSeccional(desde, hasta, seccionalId);

            var seccional = "Todas";
            if (seccionalId > 0)
            {
                seccional = db.Seccionales.Single(s => s.Id == seccionalId).Nombre;
            }

            string path = GetReportPath("RelacionAyudasAprobadas.rdlc");

            string mimetype = "";
            int extension = 1;
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("desde", desde.ToString("dd/MM/yyyy"));
            parameters.Add("hasta", hasta.ToString("dd/MM/yyyy"));
            parameters.Add("seccional", seccional);

            LocalReport lr = new LocalReport(path);

            lr.AddDataSource("DataSet", data);
            var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);

            return result.MainStream;
        }

        private DataTable GetResumenSolicitudesAprobadasPorSeccional(DateTime desde, DateTime hasta, int? seccionalId)
        {
            desde = desde.Date;
            hasta = hasta.Date.AddDays(1).AddSeconds(-1);

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"Select sec.Nombre as Seccional, 
	                   t.Nombre as TipoSolicitud, 
	                   e.Nombre as Estado, 
	                   sum(sol.MontoSolicitado) as MontoSolicitado  
                from SolicitudesAyuda sol
	                 inner join Seccionales as sec on sol.SeccionalId = sec.Id
	                 inner join TiposSolictudes as t on sol.TipoSolicitudId = t.Id
	                 inner join EstadoSolicitudes e on sol.EstadoId = e.Id
                where sol.FechaSolicitud between @desde and @hasta
                      and sol.EstadoId = 3
                      and (@seccionalId is null or sol.seccionalId = @seccionalId)
                group by  sec.Nombre, 
	                   t.Nombre, 
	                   e.Nombre";

                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@desde", desde);
                command.Parameters.AddWithValue("@hasta", hasta);

                SqlParameter prmSeccional = new SqlParameter();
                prmSeccional.ParameterName = "@seccionalId";
                prmSeccional.IsNullable = true;
                prmSeccional.DbType = DbType.Int32;

                if (!seccionalId.HasValue)
                {
                    prmSeccional.Value = DBNull.Value;
                }
                else
                {
                    prmSeccional.Value = seccionalId;
                }

                command.Parameters.Add(prmSeccional);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dt);
            }

            return dt;
        }


        public byte[] ResumenSolicitudesPorSeccional(DateTime desde, DateTime hasta, int? seccionalId)
        {
            var data = GetDataResumenSolicitudesPorSeccional(desde, hasta, seccionalId);

            string path = GetReportPath("RelacionAyudasPorSecciona.rdlc");

            string mimetype = "";
            int extension = 1;
            Dictionary<string, string> parameters = new Dictionary<string, string>();

            parameters.Add("desde", desde.ToString("dd/MM/yyyy"));
            parameters.Add("hasta", hasta.ToString("dd/MM/yyyy"));

            LocalReport lr = new LocalReport(path);

            lr.AddDataSource("DataSet", data);
            var result = lr.Execute(RenderType.Pdf, extension, parameters, mimetype);

            return result.MainStream;
        }
        private DataTable GetDataResumenSolicitudesPorSeccional(DateTime desde, DateTime hasta, int? seccionalId)
        {
            desde = desde.Date;
            hasta = hasta.Date.AddDays(1).AddSeconds(-1);

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"Select sec.Nombre as Seccional, 
	                   t.Nombre as TipoSolicitud, 
	                   e.Nombre as Estado, 
	                   sum(sol.MontoSolicitado) as MontoSolicitado  
                from SolicitudesAyuda sol
	                 inner join Seccionales as sec on sol.SeccionalId = sec.Id
	                 inner join TiposSolictudes as t on sol.TipoSolicitudId = t.Id
	                 inner join EstadoSolicitudes e on sol.EstadoId = e.Id
                where sol.FechaSolicitud between @desde and @hasta
                      and sol.EstadoId in (1,2)
                      and (@seccionalId is null or sol.seccionalId = @seccionalId)
                group by  sec.Nombre, 
	                   t.Nombre, 
	                   e.Nombre";

                var command = new SqlCommand(query, conn);
                command.Parameters.AddWithValue("@desde", desde);
                command.Parameters.AddWithValue("@hasta", hasta);

                SqlParameter prmSeccional = new SqlParameter();
                prmSeccional.ParameterName = "@seccionalId";
                prmSeccional.IsNullable = true;
                prmSeccional.DbType = DbType.Int32;

                if (!seccionalId.HasValue || seccionalId == 0)
                {
                    prmSeccional.Value = DBNull.Value;
                }
                else
                {
                    prmSeccional.Value = seccionalId;
                }

                command.Parameters.Add(prmSeccional);

                SqlDataAdapter adapter = new SqlDataAdapter(command);

                adapter.Fill(dt);
            }

            return dt;
        }
    }
}
