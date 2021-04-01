using SolicitudAyuda.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Services.Signatures
{
    public interface IFileStorageService
    {
        public void SaveFiles(int solicitudId, List<FileDataDTO> files);
        public FileDataDTO GetFile(int fileId);
        void Delete(int id);
    }
}
