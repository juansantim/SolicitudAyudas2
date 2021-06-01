using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Entities;
using SolicitudAyuda.Model.Services.Signatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;

namespace SolicitudAyuda.Model.Services
{
    public class SolicitudesService : ISolicitudesService
    {
        private readonly DataContext db;
        private readonly IConfiguration config;
        private readonly IFileStorageService fileStorageService;
        private readonly IPermisosService permisosService;

        public SolicitudesService(DataContext db, IConfiguration config, IFileStorageService fileStorageService, IPermisosService permisosService)
        {
            this.db = db;
            this.config = config;
            this.fileStorageService = fileStorageService;
            this.permisosService = permisosService;
        }

        public TipoReglamentarioOtraSolicitudDTO TiempoReglamentario
        {
            get
            {
                TipoReglamentarioOtraSolicitudDTO tiempo = new TipoReglamentarioOtraSolicitudDTO();

                tiempo.Dias = int.Parse(this.config["TiempoReglamentario:Dias"]);
                tiempo.Periodo = this.config["TiempoReglamentario:Periodo"];

                return tiempo;
            }
        }


        public dynamic GetDetalleSolicitud(int solicitudId, int usuarioId)
        {
            var solicitud = db.Solicitudes
                .Include(sl => sl.Requisitos)
                .ThenInclude(r => r.RequisitoTipoSolicitud)
                .Include(sl => sl.Adjuntos)
                .Include(sl => sl.Seccional)
                .Include(sl => sl.TipoSolicitud)
                .ThenInclude(ts => ts.Categoria)
                .Include(sl => sl.Estado)
                .Include(sl => sl.AprobacionesSolicitud)
                .Include(sl => sl.TipoSolicitud)
                .ThenInclude(ts => ts.ComisionAprobacion)
                .Include(st => st.Banco)
                .Include(sl => sl.Maestro).Single(s => s.Id == solicitudId);

            return new
            {
                solicitud.Id,
                solicitud.NumeroExpediente,
                solicitud.CedulaSolicitante,
                Seccional = solicitud.Seccional.Nombre,
                Maestro = solicitud.Maestro.NombreCompleto,
                Edad = GetEdad(solicitud.Maestro),
                FechaNacimiento = solicitud.Maestro.FechaNacimiento,
                SexoMaestro = solicitud.Maestro.Sexo,
                solicitud.FechaSolicitud,
                solicitud.Maestro.Cargo,
                solicitud.MontoSolicitado,
                solicitud.MontoAprobado,
                solicitud.TelefonoCasa,
                solicitud.Celular,
                solicitud.TelefonoTrabajo,
                solicitud.Email,
                solicitud.Direccion,
                solicitud.QuienRecibeAyuda,
                solicitud.EstadoId,
                solicitud.BancoId,
                Banco = solicitud.Banco.Nombre,
                solicitud.NumeroCuentaBanco,
                solicitud.EsJubiladoInabima,
                solicitud.OtroTipoSolicitud,
                solicitud.TipoSolicitud.CategoriaId,
                MotivoSolicitud = solicitud.Concepto,
                estado = solicitud.Estado.Nombre,
                solicitud.EstadoCuenta,
                tipoSolicitud = solicitud.TipoSolicitud.Nombre,
                solicitud.TipoSolicitudId,
                Requisitos = solicitud.Requisitos.Select(rq => GetRequisitosParaDetalle(rq)),
                Adjuntos = solicitud.Adjuntos.Select(ad => GetAdjunto(ad)),
                DatosAprobacion = GetDatosAprobacion(solicitud),
                ProcesadaPorUsuario = solicitud.AprobacionesSolicitud.Any(ap => ap.UsuarioId == usuarioId),
                solicitud.ActaNacimientoHijoHija,
                solicitud.CopiaCedulaPadreMadre,
                solicitud.ActaMatrimonioUnion,

            };
        }

        private int GetEdad(Maestro maestro)
        {
            try
            {
                return new DateTime((DateTime.Now - maestro.FechaNacimiento).Ticks).Year - 1;
            }
            catch (Exception ex)
            {
                return 0;
            }

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
                requisito.RequisitoTipoSolicitud.FormName,
                requisito.RequisitoTipoSolicitud.PossibleValues,
                Nombre = tipo.Descripcion,
                Descripcion = tipo.Descripcion,
                requisito.Value,
                Values = Getvalues(tipo)
            };
        }

        public List<string> Getvalues(RequisitoTipoSolicitud r)
        {
            return string.IsNullOrEmpty(r.PossibleValues) ? new List<string>() : r.PossibleValues.Split(",").ToList();
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
                .Include(sc => sc.Estado)
                .OrderBy(sc => sc.Id).AsQueryable();

            if (!string.IsNullOrEmpty(filtro.Cedula))
            {
                query = query.Where(q => q.CedulaSolicitante == filtro.Cedula);
            }

            if (filtro.SeccionalId > 0)
            {
                query = query.Where(q => q.SeccionalId == filtro.SeccionalId);
            }

            if (filtro.SolicitudDesde.HasValue)
            {
                query = query.Where(q => q.FechaSolicitud >= filtro.SolicitudDesde);
            }

            if (filtro.SolicitudHasta.HasValue)
            {
                query = query.Where(q => q.FechaSolicitud <= filtro.SolicitudHasta);
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

        public bool TieneSolicitudElMismoDia(Maestro maestro)
        {
            var desde = DateTime.Now.AddDays(-1);
            var hasta = DateTime.Now;

            return db.Solicitudes.Any(s =>
            s.CedulaSolicitante == maestro.Cedula &&
            s.FechaSolicitud >= desde &&
            s.FechaSolicitud <= hasta && (s.EstadoId != 4 && s.EstadoId != 5));
        }

        public List<UltimasSolicitudesDTO> TieneSolicitudAntesTiempoReglamentario(Maestro maestro)
        {
            var desde = DateTime.Now.AddDays(-this.TiempoReglamentario.Dias);
            var hasta = DateTime.Now;

            return db.Solicitudes
                .Include(s => s.Estado)
                .Include(s => s.TipoSolicitud)
                .Where(s => s.CedulaSolicitante == maestro.Cedula &&
            s.FechaSolicitud >= desde &&
            s.FechaSolicitud <= hasta && (s.EstadoId != 4 && s.EstadoId != 5))
                .Select(t => new UltimasSolicitudesDTO
                {
                    Estado = t.Estado.Nombre,
                    Tipo = t.TipoSolicitud.Nombre,
                    Numero = t.NumeroExpediente,
                    Fecha = t.FechaSolicitud
                }).ToList();
        }

        public Movimiento DetectarCambios(Entities.SolicitudAyuda actualSolicitud, DataContext Currentdb)
        {
            var entry = Currentdb.Entry(actualSolicitud);

            if (entry.State == EntityState.Modified)
            {
                Movimiento m = new Movimiento();
                m.Key = actualSolicitud.Id.ToString();
                m.Entidad = entry.Metadata.GetTableName();

                var currentValues = entry.CurrentValues;
                var originalValues = entry.OriginalValues;

                foreach (var current in currentValues.Properties)
                {
                    object originalValue = originalValues[current];
                    object currentValue = currentValues[current];

                    if (GetValue(originalValue) != GetValue(currentValue))
                    {
                        m.Cambios.Add(new Cambio
                        {
                            Propiedad = current.Name,
                            Antes = GetValue(originalValue),
                            Despues = GetValue(currentValue)
                        });

                    }
                }
                return m;
            }

            return null;
        }


        string GetValue(object value)
        {
            var finalValue = value == null ? "" : value.ToString();

            if (finalValue == "null")
            {
                finalValue = "";
            }

            if (isDecimal(finalValue))
            {
                return decimal.Parse(finalValue).ToString("N2");
            }

            if (isInteger(finalValue))
            {
                return int.Parse(finalValue).ToString("N0");
            }

            return finalValue;
        }

        bool isDecimal(object value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            else
            {
                var stringValue = value.ToString();
                decimal output;

                if (decimal.TryParse(stringValue, out output))
                {
                    if (stringValue.Contains("."))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }

                return false;
            }
        }

        bool isInteger(object value)
        {
            if (string.IsNullOrEmpty(value.ToString()))
            {
                return false;
            }
            else
            {
                var stringValue = value.ToString();
                int output;

                if (int.TryParse(stringValue, out output))
                {
                    if (stringValue.Contains("."))
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        public Maestro GetMaestro(MaestroDto maestroDto, SolicitudAyuda.Model.Entities.SolicitudAyuda solicitud, HttpDataResponse response)
        {
            var maestro = db.Maestros.FirstOrDefault(ma => ma.Cedula == maestroDto.Cedula);

            if (maestro != null)
            {
                if (TieneSolicitudElMismoDia(maestro))
                {
                    response.AddError("Ya esta persona tiene una solicitud registrada hace menos de 24 horas");
                }

                var solicitudesAnteriores = TieneSolicitudAntesTiempoReglamentario(maestro);

                if (solicitudesAnteriores.Count > 0)
                {
                    foreach (var s in solicitudesAnteriores)
                    {
                        response.AddError($"Este filiado tiene la solicitud #{s.Numero} - {s.Tipo} ({s.Estado}) {s.Fecha.ToString("dd/MM/yyyy")} hace menos de {TiempoReglamentario.Periodo}");
                    }
                }
            }
            else
            {
                maestro = new Maestro
                {
                    Cedula = maestroDto.Cedula,
                    NombreCompleto = maestroDto.NombreCompleto,
                    Cargo = maestroDto.Cargo,
                    SeccionalId = maestroDto.SeccionalId,
                    Sexo = maestroDto.Sexo,
                    FechaNacimiento = maestroDto.FechaNacimiento,
                    Direccion = solicitud.Direccion,
                    TelefonoCelular = solicitud.Celular,
                    TelefonoLabora = solicitud.TelefonoTrabajo,
                    TelefonoResidencial = solicitud.TelefonoCasa,
                };
            }

            return maestro;
        }

        public List<FileDataDTO> GetFilesToUpLoad(IFormFileCollection requestFiles)
        {
            List<FileDataDTO> files = new List<FileDataDTO>();

            if (requestFiles.Count > 0)
            {
                foreach (var file in requestFiles)
                {
                    files.Add(new FileDataDTO
                    {
                        OriginalFileName = file.FileName,
                        Content = file.OpenReadStream(),
                        ContenType = file.ContentType
                    });
                }
            }

            return files;
        }

        public HttpDataResponse CreateSolicitud(Entities.SolicitudAyuda solicitud, IFormFileCollection requestFiles, int usuarioId)
        {
            HttpDataResponse response = new HttpDataResponse();

            solicitud.EstadoId = 1;
            solicitud.UsuarioId = usuarioId;
            solicitud.FechaSolicitud = DateTime.Now;

            List<FileDataDTO> files = GetFilesToUpLoad(requestFiles);
            db.Solicitudes.Add(solicitud);

            using (TransactionScope scope = new TransactionScope())
            {
                db.SaveChanges();
                fileStorageService.SaveFiles(solicitud.Id, files);

                scope.Complete();
            }

            return response;
        }

        public HttpDataResponse Update(Entities.SolicitudAyuda solicitud, IFormFileCollection requestFiles, int usuarioId)
        {
            HttpDataResponse response = new HttpDataResponse();

            if (this.permisosService.VerificarPermiso(usuarioId, 9))
            {
                var actualSolicitud = db.Solicitudes.Single(s => s.Id == solicitud.Id);

                actualSolicitud.MontoSolicitado = solicitud.MontoSolicitado;
                actualSolicitud.BancoId = solicitud.BancoId;
                actualSolicitud.NumeroCuentaBanco = solicitud.NumeroCuentaBanco;
                actualSolicitud.TelefonoCasa = solicitud.TelefonoCasa;
                actualSolicitud.TelefonoTrabajo = solicitud.TelefonoTrabajo;
                actualSolicitud.Email = solicitud.Email;
                actualSolicitud.Direccion = solicitud.Direccion;
                actualSolicitud.Concepto = solicitud.Concepto;
                actualSolicitud.OtroTipoSolicitud = solicitud.OtroTipoSolicitud;
                actualSolicitud.FechaSolicitud = solicitud.FechaSolicitud;

                List<FileDataDTO> files = GetFilesToUpLoad(requestFiles);

                var movimiento = DetectarCambios(actualSolicitud, this.db);
                movimiento.UsuarioId = usuarioId;

                db.Movimientos.Add(movimiento);

                using (TransactionScope scope = new TransactionScope())
                {
                    db.SaveChanges();
                    scope.Complete();
                }

                fileStorageService.SaveFiles(actualSolicitud.Id, files);

                response.Data = new { solicitudId = actualSolicitud.Id };
            }
            else
            {
                response.AddError("Usted no tiene permisos para realizar esta accion");
            }

            return response;
        }
    }
}
