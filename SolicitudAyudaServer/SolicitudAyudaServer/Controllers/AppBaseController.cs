using Microsoft.AspNetCore.Mvc;
using SolicitudAyuda.Model;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SolicitudAyudaServer.Controllers
{

    public class AppBaseController : ControllerBase
    {
        private readonly DataContext db;

        public AppBaseController(DataContext db)
        {
            this.db = db;
        }
        public int UsuarioId
        {
            get
            {
                if (User != null)
                {
                    if (User.Claims.Count() > 0)
                    {
                        return int.Parse(User.Claims.Where(c => c.Type == "UsuarioId").FirstOrDefault().Value);
                    }
                }

                throw new InvalidOperationException("Usuario o autenticado"); ;
            }
        }

        public Usuario CurrentUsuario
        {
            get
            {
                try
                {
                    return db.Usuarios.Single(u => u.Id == UsuarioId);
                }
                catch (Exception)
                {

                    return null;
                }
            }
        }

    }
}
