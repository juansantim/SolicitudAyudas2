using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Services.Signatures
{
    public interface IPermisosService
    {
        bool VerificarPermiso(int usuarioId, int permisoId);
    }
}
