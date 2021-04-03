﻿using SolicitudAyuda.Model.DTOs;
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
        bool TieneSolicitudElMismoDia(Maestro maestro);
        TipoReglamentarioOtraSolicitudDTO TiempoReglamentario { get; }
        List<UltimasSolicitudesDTO> TieneSolicitudAntesTiempoReglamentario(Maestro maestro);
        List<string> Getvalues(RequisitoTipoSolicitud r);
        Movimiento DetectarCambios(Entities.SolicitudAyuda actualSolicitud, DataContext db);
    }
}
