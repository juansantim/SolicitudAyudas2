using Microsoft.AspNetCore.Http;
using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Services.Signatures
{
    public interface ISolicitudesService
    {
        dynamic GetDetalleSolicitud(int solicitudId, int usuarioId);
        PaginatedResult<SolicitudConsultaDTO> GetDataConsulta(FiltroSolicitudesDTO filtro);
        byte[] ImprimirPDF(int solicitudId, int formato);
        bool TieneSolicitudElMismoDia(Maestro maestro, int solicitudId);
        TipoReglamentarioOtraSolicitudDTO TiempoReglamentario { get; }
        List<UltimasSolicitudesDTO> TieneSolicitudAntesTiempoReglamentario(Maestro maestro, int solicitudId);
        List<string> Getvalues(RequisitoTipoSolicitud r);
        Movimiento DetectarCambios(Entities.SolicitudAyuda actualSolicitud, DataContext db);
        Maestro GetMaestro(MaestroDto maestroDto, SolicitudAyuda.Model.Entities.SolicitudAyuda solicitud, HttpDataResponse response);
        List<FileDataDTO> GetFilesToUpLoad(IFormFileCollection files);
        HttpDataResponse Submit(Entities.SolicitudAyuda solicitud, IFormFileCollection requestFiles, int usuarioId);
        //HttpDataResponse Update(Entities.SolicitudAyuda solicitud, IFormFileCollection requestFiles, int usuarioId);
        Entities.SolicitudAyuda AnularSolicitud(int solicitudId);
    }
}
