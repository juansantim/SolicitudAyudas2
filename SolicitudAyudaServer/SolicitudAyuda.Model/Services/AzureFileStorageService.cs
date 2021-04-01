using Azure.Storage.Blobs;
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
    public class AzureFileStorageService : IFileStorageService
    {
        private readonly BlobServiceClient blobService;
        private readonly DataContext db;
        private readonly IConfiguration config;

        private string ContainerName
        {
            get
            {
                if (config.GetConnectionString("adp").Contains("adpsqlserver1"))
                {
                    return "solicitudesayuda";
                }
                else
                {
                    return "solicitudesayudatests";
                }
            }
        }

        public AzureFileStorageService(BlobServiceClient blobService, DataContext db, IConfiguration config)
        {
            this.blobService = blobService;
            this.db = db;
            this.config = config;
        }
        public FileDataDTO GetFile(int fileId)
        {
            var adjunto = GetAdjuntoSolicitud(fileId);
            var containerClient = blobService.GetBlobContainerClient(ContainerName);

            var blobClient = containerClient.GetBlobClient(adjunto.URL);
            var blobInfo = blobClient.Download();

            return new FileDataDTO
            {
                Content = blobInfo.Value.Content,
                ContenType = adjunto.ContentType
            };
        }

        private AdjuntosSolicitud GetAdjuntoSolicitud(int fileId) 
        {
            return db.AdjuntosSolicitudes.Single(ad => ad.Id == fileId);
        }
              
        public void SaveFiles(int solicitudId, List<FileDataDTO> files)
        {
            foreach (var item in files)
            {
                var fileName = Guid.NewGuid().ToString();
                var extension = Path.GetExtension(item.OriginalFileName);

                item.FileName = $"{fileName}{extension}";

                db.AdjuntosSolicitudes.Add(new Entities.AdjuntosSolicitud
                {
                    DisplayName = item.OriginalFileName,
                    SolicitudAyudaId = solicitudId,
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

        public void Delete(int fileId)
        {
            var file = GetAdjuntoSolicitud(fileId);
            var solicitud = db.Solicitudes.Include(s => s.Estado).Single(s => s.Id == file.SolicitudAyudaId);

            if (file.SolicitudAyuda.EstadoId == 1)
            {
                var containerClient = blobService.GetBlobContainerClient(ContainerName);
                var blobClient = containerClient.GetBlobClient(file.URL);

                var response = blobClient.Delete(Azure.Storage.Blobs.Models.DeleteSnapshotsOption.IncludeSnapshots);
                if (response.Status == 202) 
                {
                    db.AdjuntosSolicitudes.Remove(file);
                    db.SaveChanges();
                }
            }
            else {
                throw new InvalidOperationException($"No se puede elimar archivo porque solicitud se encuentra {solicitud.Estado.Nombre}");
            }
        }
    }
}
