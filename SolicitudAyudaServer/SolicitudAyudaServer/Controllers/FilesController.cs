using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using SolicitudAyuda.Model;

namespace SolicitudAyudaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly DataContext db;
        private readonly IConfiguration config;

        public FilesController(DataContext db, IConfiguration config)
        {
            this.db = db;
            this.config = config;
        }

        [Route("download")]
        public FileResult download(int id)
        {
            var file = db.AdjuntosSolicitudes.Single(ad => ad.Id == id);
            var fileName = System.IO.Path.GetFileName(file.URL);
            var Url = config["FilesUrl"];

            var bytes = System.IO.File.ReadAllBytes($"{Url}/{fileName}");
            //fileName = 
            return File(bytes, file.ContentType, true);

            //return "Ok";
        }
    }
}
