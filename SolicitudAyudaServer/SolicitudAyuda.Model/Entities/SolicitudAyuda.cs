using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace SolicitudAyuda.Model.Entities
{
    [Table("SolicitudesAyuda")]
    public class SolicitudAyuda
    {
        public int Id { get; set; }
        public int NumeroExpediente { get; set; }
        public string CedulaSolicitante { get; set; }
        
        public int MaestroId { get; set; }
        public Maestro Maestro { get; set; }

        public int SeccionalId { get; set; }
        public Seccional Seccional { get; set; }

        public string Celular { get; set; }
        public string TelefonoCasa { get; set; }
        public string TelefonoTrabajo { get; set; }
        public string Email { get; set; }

        public byte? QuienRecibeAyuda { get; set; }

        public DateTime FechaSolicitud { get; set; }
        public DateTime? FechaAprobacion { get; set; }
        public int TipoSolicitudId { get; set; }
        public TipoSolicitud TipoSolicitud { get; set; }

        public string OtroTipoSolicitud { get; set; }

        public List<RequisitoSolicitud> Requisitos { get; set; }
        public List<AdjuntosSolicitud> Adjuntos { get; set; }

        public List<AprobacionSolicitud> AprobacionesSolicitud { get; set; }
        public string Concepto { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal? MontoAprobado { get; set; }
        public int UsuarioId { get; set; }
        public Usuario Usuario { get; set; }

        public int EstadoId { get; set; }
        public EstadoSolicitud Estado { get; set; }
        public string Direccion { get; set; }

        public int BancoId { get; set; }
        public Banco Banco { get; set; }
        public string NumeroCuentaBanco { get; set; }

        public bool? ActaNacimientoHijoHija { get; set; }
        public bool? CopiaCedulaPadreMadre { get; set; }
        public bool? ActaMatrimonioUnion { get; set; }
        public bool? EsJubiladoInabima { get; set; }
        public bool? EstadoCuenta { get; set; }
        public List<ComentarioSolicitud> Comentarios { get; set; }

        public SolicitudAyuda()
        {
            Requisitos = new List<RequisitoSolicitud>();
            Adjuntos = new List<AdjuntosSolicitud>();
            Comentarios = new List<ComentarioSolicitud>();
        }
    }
}
