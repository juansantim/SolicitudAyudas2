using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Entities;
using SolicitudAyuda.Model.Services.Signatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SolicitudAyuda.Model.Services
{
    public class SolicitudesService : ISolicitudesService
    {
        private readonly DataContext db;
        private readonly IConfiguration config;

        public SolicitudesService(DataContext db, IConfiguration config)
        {
            this.db = db;
            this.config = config;
        }

        public dynamic GetDetalleSolicitud(int solicitudId, int usuarioId)
        {
            var solicitud = db.Solicitudes
                .Include(sl => sl.Requisitos)
                .Include(sl => sl.Adjuntos)
                .Include(sl => sl.Seccional)
                .Include(sl => sl.TipoSolicitud)
                .Include(sl => sl.Estado)
                .Include(sl => sl.AprobacionesSolicitud)
                .Include(sl => sl.TipoSolicitud)
                .ThenInclude(ts => ts.ComisionAprobacion)
                .Include(sl => sl.Maestro).Single(s => s.Id == solicitudId);

            return new
            {
                solicitud.Id,
                solicitud.NumeroExpediente,
                solicitud.CedulaSolicitante,
                Seccional = solicitud.Seccional.Nombre,
                NombreSolicitante = solicitud.Maestro.NombreCompleto,
                Edad = new DateTime((DateTime.Now - solicitud.Maestro.FechaNacimiento).Ticks).Year - 1,
                SexoSolicitante = solicitud.Maestro.Sexo,
                solicitud.Maestro.Cargo,
                solicitud.MontoSolicitado,
                solicitud.MontoAprobado,
                solicitud.TelefonoCasa,
                solicitud.Celular,
                solicitud.TelefonoTrabajo,
                solicitud.Email,
                solicitud.Direccion,
                solicitud.EstadoId,
                estado = solicitud.Estado.Nombre,
                tipoSolicitud = solicitud.TipoSolicitud.Nombre,
                solicitud.TipoSolicitudId,
                Requisitos = solicitud.Requisitos.Select(rq => GetRequisitosParaDetalle(rq)),
                Adjuntos = solicitud.Adjuntos.Select(ad => GetAdjunto(ad)),
                DatosAprobacion = GetDatosAprobacion(solicitud),
                ProcesadaPorUsuario = solicitud.AprobacionesSolicitud.Any(ap => ap.UsuarioId == usuarioId)
            };
        }

        private dynamic GetDatosAprobacion(Entities.SolicitudAyuda solicitud)
        {
            List<StatusUsuarioAprobacionSolicitudDTO> statusAprobacion = new List<StatusUsuarioAprobacionSolicitudDTO>();


            var comision = solicitud.TipoSolicitud.ComisionAprobacion;

            db.Entry(comision).Collection(c => c.UsuariosComisionAprobacion).Load();

            foreach (var miembro in comision.UsuariosComisionAprobacion)
            {
                var usuarioMiembro = db.Usuarios.Single(u => u.Id == miembro.UsuarioId);
                var aprobacionUsuario = solicitud.AprobacionesSolicitud.SingleOrDefault(ap => ap.UsuarioId == miembro.UsuarioId);

                if (aprobacionUsuario != null)
                {
                    db.Entry(aprobacionUsuario).Reference(r => r.Estado).Load();

                    statusAprobacion.Add(new StatusUsuarioAprobacionSolicitudDTO
                    {
                        EstadoId = aprobacionUsuario.EstadoId,
                        Usuario = usuarioMiembro.NombreCompleto,
                        Fecha = aprobacionUsuario.Fecha,
                        Estado = aprobacionUsuario.Estado.Nombre,
                        Comentario = aprobacionUsuario.Comentario
                    });
                }
                else
                {
                    statusAprobacion.Add(new StatusUsuarioAprobacionSolicitudDTO
                    {
                        EstadoId = 0,
                        Usuario = usuarioMiembro.NombreCompleto,
                        Fecha = null,
                        Estado = null,
                        Comentario = "No ha ejecutado ninguna acción"
                    });
                }
            }


            return statusAprobacion;
        }

        private dynamic GetRequisitosParaDetalle(RequisitoSolicitud requisito)
        {
            var tipo = db.RequisitosTipoSolicitudes.Single(rq => rq.Id == requisito.RequisitoTiposSolicitudId);

            return new
            {
                requisito.Id,
                Nombre = tipo.Descripcion,
                requisito.Value
            };
        }

        private dynamic GetAdjunto(AdjuntosSolicitud ad)
        {
            var fileName = System.IO.Path.GetFileName(ad.URL);

            return new
            {
                ad.Id,
                ad.ContentType,
                ad.SizeMB,
                ad.DisplayName
            };
        }

        public PaginatedResult<SolicitudConsultaDTO> GetDataConsulta(FiltroSolicitudesDTO filtro)
        {
            PaginatedResult<SolicitudConsultaDTO> result = new PaginatedResult<SolicitudConsultaDTO>();

            var query = db.Solicitudes
                .Include(sc => sc.Maestro)
                .Include(sc => sc.TipoSolicitud)
                .Include(sc => sc.Estado).AsQueryable();

            if (!string.IsNullOrEmpty(filtro.cedula))
            {
                query = query.Where(q => q.CedulaSolicitante == filtro.cedula);
            }

            if (filtro.seccionalId > 0)
            {
                query = query.Where(q => q.SeccionalId == filtro.seccionalId);
            }

            if (filtro.solicitudDesde.HasValue)
            {
                query = query.Where(q => q.FechaSolicitud >= filtro.solicitudDesde);
            }

            if (filtro.solicitudHasta.HasValue)
            {
                query = query.Where(q => q.FechaSolicitud <= filtro.solicitudHasta);
            }

            decimal itemsCount = query.Any() ? query.Count() : 0;

            query = query.Skip((filtro.Page - 1) * filtro.ItemsPerPage).Take(filtro.ItemsPerPage);

            if (itemsCount > 0)
            {
                result.TotalItems = Convert.ToInt32(itemsCount);
                //result.TotalItems = Convert.ToInt32(Math.Ceiling(itemsCount / Convert.ToDecimal(filtro.ItemsPerPage)));
            }

            result.Data = query.Select(sc => new SolicitudConsultaDTO
            {
                Id = sc.Id,
                Cedula = sc.CedulaSolicitante,
                TipoSolicitud = sc.TipoSolicitud.Nombre,
                Solicitante = sc.Maestro.NombreCompleto,
                Seccional = sc.Seccional.Nombre,
                Estado = sc.Estado.Nombre,
                EstadoId = sc.EstadoId,
                MontoSolicitado = sc.MontoSolicitado,
                MontoAprobado = sc.MontoAprobado ?? 0,
                FechaSolicitud = sc.FechaSolicitud,
                FechaAprobacion = sc.FechaAprobacion

            }).ToList();

            return result;
        }

        public byte[] ImprimirPDF(int solicitudId, int formato)
        {
            if (formato == 1)
            {
                throw new NotImplementedException();
            }
            else if (formato == 2)
            {
                var text = GetsolicitudTxt(solicitudId);

                string systemFont = $"{config["RootUrl"]}fonts\\MODES__.TTF";
                //Create a base font object making sure to specify IDENTITY-H
                BaseFont bf = BaseFont.CreateFont(systemFont, BaseFont.IDENTITY_H, BaseFont.NOT_EMBEDDED);

                iTextSharp.text.Font f = new iTextSharp.text.Font(bf, 8, iTextSharp.text.Font.NORMAL);

                MemoryStream memoryStream = new MemoryStream();
                Document doc = new Document(new iTextSharp.text.Rectangle(216, 792), 10, 10, 0, 0); //inc * 72 (in pixels)
                PdfWriter writer = PdfWriter.GetInstance(doc, memoryStream);
                doc.Open();
                doc.Add(new Paragraph(text, f));
                doc.Close();

                byte[] data = memoryStream.ToArray();

                return data;
            }

            throw new NotImplementedException();


        }

        private string GetsolicitudTxt(int solicitudId)
        {
            StringBuilder bldr = new StringBuilder();

            var solicitud = db.Solicitudes
                .Include(s => s.Maestro)
                .Include(s => s.Seccional)
                .Include(s => s.Estado)
                .Include(s => s.Requisitos)
                .Include(s => s.TipoSolicitud)
                .Single(s => s.Id == solicitudId);

            bldr.Append($"ASOCIACION DOMINICANA DE PROFEDORES {Environment.NewLine}");
            bldr.Append($"RECEPCION DE SOLICITUD DE AYUDA {Environment.NewLine}");
            bldr.Append($"NUMERO SOLICITUD: {solicitud.NumeroExpediente} {Environment.NewLine}");
            bldr.Append($"NOMBRE: {solicitud.Maestro.NombreCompleto.ToUpper()} {Environment.NewLine}");
            bldr.Append($"SECCIONAL: {solicitud.Seccional.Nombre.ToUpper()} {Environment.NewLine}");
            bldr.Append($"TIPO SOLICITUD: {solicitud.TipoSolicitud.Nombre.ToUpper()} {Environment.NewLine}");
            bldr.Append($"MONTO SOLICITADO: {solicitud.MontoSolicitado.ToString("N2")} {Environment.NewLine}");
            bldr.Append($"FECHA SOLICITUD: {solicitud.FechaSolicitud.ToString("dd/MM/yyyy hh:mm tt")} {Environment.NewLine}");
            bldr.Append($"DOCUMENTACION ENTREGADA:");
            bldr.Append($"{Environment.NewLine}");
            foreach (var item in solicitud.Requisitos)
            {
                var tipo = db.RequisitosTipoSolicitudes.Single(t => t.Id == item.RequisitoTiposSolicitudId);
                if (string.IsNullOrEmpty(tipo.PossibleValues))
                {
                    bldr.Append($"->{tipo.Descripcion.ToUpper()}");
                }
                else
                {
                    bldr.Append($"->{tipo.Descripcion.ToUpper()}: {item.Value}");
                }

                bldr.Append($"{Environment.NewLine}");
                bldr.Append($"{Environment.NewLine}");
            }
            bldr.Append($"MOTIVACION: {solicitud.Concepto.ToUpper()} {Environment.NewLine}");

            return bldr.ToString();

        }

        public static string SplitLineToMultiline(string input, int rowLength)
        {
            StringBuilder result = new StringBuilder();
            StringBuilder line = new StringBuilder();

            Queue<string> queue = new Queue<string>(input.Split(' '));

            while (queue.Count > 0)
            {
                var word = queue.Dequeue();
                if (word.Length > rowLength)
                {
                    string head = word.Substring(0, rowLength);
                    string tail = word.Substring(rowLength);

                    word = head;
                    queue.Enqueue(tail);
                }

                if (line.Length + word.Length > rowLength)
                {
                    result.AppendLine(line.ToString());
                    line.Clear();
                }

                line.Append(word + " ");
            }

            result.Append(line);
            return result.ToString();
        }
    }
}
