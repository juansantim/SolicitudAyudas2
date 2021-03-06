using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SolicitudAyuda.Model.Services.Signatures
{
    public interface IUsuariosService
    {
        PaginatedResult<UsuariosConsultaDTO> GetDataConsulta(FiltroDataUsuarioDTO filtro);
        Usuario GetById(int usuarioId);

        Usuario GetByIdAndChangePasswordCode(int usuarioId, string code);

        List<PermisoUsuarioDTO> GetPermisosUsuario(int usuarioId);
        List<ComisionAprobacionUsuarioDTO> GetComisionesAprobacion(int usuarioId);

        List<PermisoUsuarioDTO> GetPermisosUsuario();
        List<ComisionAprobacionUsuarioDTO> GetComisionesAprobacion();
        void ActivarUsuario(ActivacionUsuarioDTO usuario);
        string EnableResetPassword(int usuarioId);
        HttpDataResponse VerificarEmailExiste(CreacionUsuarioDTO usuarioDTO);
        Usuario Submit(CreacionUsuarioDTO usuarioDTO);
    }
}
