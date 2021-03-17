using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SolicitudAyuda.Model;
using SolicitudAyuda.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolicitudAyudaServer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BancosController : ControllerBase
    {
        private readonly DataContext db;

        public BancosController(DataContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public List<BancoForSelectDTO> Get()
        {
            var bancos = this.db.Banco.AsNoTracking().Select(b => new BancoForSelectDTO
            {
                Id = b.Id,
                Nombre = b.Nombre
            }).ToList();

            var bancosPrincipales = bancos.Where(b => b.Id == 1 || b.Id == 2).ToList();

            foreach (var item in bancosPrincipales)
            {
                bancos.Remove(item);
            }

            bancos = bancos.OrderBy(b => b.Nombre).ToList();

            foreach (var item in bancosPrincipales)
            {

                bancos.Insert(0, item);
            }

            bancos.Insert(0, new BancoForSelectDTO
            {
                Id = null,
                Nombre = "--Seleccione--"
            });

            return bancos; 
        }
    }
}
