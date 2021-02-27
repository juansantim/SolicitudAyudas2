using Azure.Storage.Blobs;
using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Services.Signatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace SolicitudAyuda.Model.Services
{
    public class AzureFileStorageService : IFileStorageService
    {
        private readonly BlobServiceClient blobService;
        private readonly DataContext db;
        private string ContainerName = "solicitudesayuda";

        public AzureFileStorageService(BlobServiceClient blobService, DataContext db)
        {
            this.blobService = blobService;
            this.db = db;
        }
        public FileDataDTO GetFile(int fileId)
        {
            var adjunto = db.AdjuntosSolicitudes.Single(ad => ad.Id == fileId);
            var containerClient = blobService.GetBlobContainerClient(ContainerName);

            var blobClient = containerClient.GetBlobClient(adjunto.URL);
            var blobInfo = blobClient.Download();

            return new FileDataDTO
            {
                Content = blobInfo.Value.Content,
                ContenType = adjunto.ContentType
            };
        }

        public void SaveFiles(Entities.SolicitudAyuda solicitud, List<FileDataDTO> files)
        {
            foreach (var item in files)
            {
                var fileName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(item.OriginalFileName);

                item.FileName = $"{fileName}{extension}";

                db.AdjuntosSolicitudes.Add(new Entities.AdjuntosSolicitud
                {
                    DisplayName = item.OriginalFileName,
                    SolicitudAyudaId = solicitud.Id,
                    SizeMB = (item.Content.Length / 1024) / 1024,
                    ContentType = item.ContenType,
                    URL = item.FileName   
                });

                SaveToAzure(item);
            }

            db.SaveChanges();
        }

        private void SaveToAzure(FileDataDTO file) 
        {
            var containerClient = blobService.GetBlobContainerClient(ContainerName);
            var blobClient = containerClient.GetBlobClient(file.FileName);
            var blobInfo = blobClient.Upload(file.Content);            
        }

    }
}
