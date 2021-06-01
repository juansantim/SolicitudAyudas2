using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;
using SolicitudAyuda.Model;
using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Services.Signatures;

namespace SolicitudAyudaServer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly DataContext db;
        private readonly IConfiguration config;
        private readonly IFileStorageService fileStorageService;

        public FilesController(DataContext db, IConfiguration config, IFileStorageService fileStorageService)
        {
            this.db = db;
            this.config = config;
            this.fileStorageService = fileStorageService;
        }

        [Route("download")]
        public FileResult download(int id)
        {
            var file = fileStorageService.GetFile(id);

            return File(file.Content, file.ContenType);
        }

        [Route("delete")]
        [HttpDelete]
        public HttpDataResponse delete(int id)
        {
            HttpDataResponse response = new HttpDataResponse();

            try
            {
                fileStorageService.Delete(id);
            }
            catch (Exception ex)
            {
                response.AddError("Archivo no existe en Storage");
            }
            
            return response;
        }

    }
}
