using SolicitudAyuda.Model.Services.Signatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SolicitudAyuda.Model.Services
{
    public class PermisosService : IPermisosService
    {
        private readonly DataContext db;

        public PermisosService(DataContext db)
        {
            this.db = db;
        }
        public bool VerificarPermiso(int usuarioId, int permisoId)
        {
            var permisoUsuario = db.PermisosUsuarios.FirstOrDefault(pu => pu.UsuarioId == usuarioId && pu.PermisoId == permisoId);

            if (permisoUsuario != null) 
            {
                return permisoUsuario.Disponible;
            }

            return false;
        }
    }
}
