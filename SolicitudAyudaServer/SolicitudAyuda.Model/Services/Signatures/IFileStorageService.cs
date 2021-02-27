using SolicitudAyuda.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Services.Signatures
{
    public interface IFileStorageService
    {
        public void SaveFiles(SolicitudAyuda.Model.Entities.SolicitudAyuda solicitud, List<FileDataDTO> files);
        public FileDataDTO GetFile(int fileId);
    }
}
