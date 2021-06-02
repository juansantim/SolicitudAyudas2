using Microsoft.EntityFrameworkCore;
using SolicitudAyuda.Model.DTOs;
using SolicitudAyuda.Model.Entities;
using SolicitudAyuda.Model.Services.Signatures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Transactions;

namespace SolicitudAyuda.Model.Services
{
    public class UsuariosService : IUsuariosService
    {
        private readonly DataContext db;

        public UsuariosService(DataContext db)
        {
            this.db = db;
        }

        public Usuario GetById(int usuarioId)
        {
            return db.Usuarios
                .Include(u => u.Seccional)
                .Include(u => u.Maestro)
                .Include(u => u.PermisosUsuario)
                .ThenInclude(pu => pu.Permiso).Single(u => u.Id == usuarioId);
        }

        public PaginatedResult<UsuariosConsultaDTO> GetDataConsulta(FiltroDataUsuarioDTO filtro)
        {
            PaginatedResult<UsuariosConsultaDTO> result = new PaginatedResult<UsuariosConsultaDTO>();

            var query = db.Usuarios
                .Include(u => u.Seccional)
                .Include(u => u.UsuariosComisionesAprobacion)
                .ThenInclude(uc => uc.ComisionAprobacion)
                .Include(u => u.PermisosUsuario)
                .ThenInclude(pu => pu.Permiso)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filtro.SearchText))
            {
                query = query.Where(q =>
                q.Email.Contains(filtro.SearchText) ||
                q.NombreCompleto.Contains(filtro.SearchText));
            }

            decimal itemsCount = query.Any() ? query.Count() : 0;

            query = query.Skip((filtro.Page - 1) * filtro.ItemsPerPage).Take(filtro.ItemsPerPage);

            if (itemsCount > 0)
            {
                result.TotalItems = Convert.ToInt32(itemsCount);
            }

            result.Data = query.Select(u => new UsuariosConsultaDTO
            {
                Id = u.Id,
                NombreCompleto = u.NombreCompleto,
                Disponible = u.Disponible,
                Email = u.Email,
                Seccional = u.Seccional.Nombre,
                SeccionalId = u.SeccionalId,
                Permisos = u.PermisosUsuario.Where(pu => pu.Disponible).Select(pu => pu.Permiso.Nombre).ToList(),
                Comisiones = u.UsuariosComisionesAprobacion.Where(cu => cu.Disponible).Select(cu => cu.ComisionAprobacion.Nombre).ToList()
            }).ToList();

            return result;
        }

        public List<PermisoUsuarioDTO> GetPermisosUsuario(int usuarioId)
        {
            var permisos = db.Permisos.ToList();
            var permisosUsuarios = db.PermisosUsuarios.Where(pu => pu.UsuarioId == usuarioId);

            return permisos.Select(p => new PermisoUsuarioDTO
            {
                PermisoId = p.Id,
                Nombre = p.Nombre,
                Checked = permisosUsuarios.Any(px => px.PermisoId == p.Id && px.Disponible),
            }).ToList();
        }

        public List<ComisionAprobacionUsuarioDTO> GetComisionesAprobacion(int usuarioId)
        {
            var comisiones = db.ComisionesAprobacion.ToList();
            var comisionesUsuario = db.UsuarioComisionAprobacion.Where(cu => cu.UsuarioId == usuarioId && cu.Disponible);

            var comisionesResult = new List<ComisionAprobacionUsuarioDTO>();

            foreach (var c in comisiones)
            {
                var cUsuario = comisionesUsuario.FirstOrDefault(cu => cu.ComisionAprobacionId == c.Id);
                bool Checked = cUsuario != null;

                comisionesResult.Add(new ComisionAprobacionUsuarioDTO
                {
                    Checked = Checked,
                    ComisionAprobacionId = c.Id,
                    Nombre = c.Nombre,
                    UsuarioCreacionId = cUsuario == null ? 0 : cUsuario.UsuarioCreacionId,
                    UsuarioId = cUsuario == null ? 0 : cUsuario.UsuarioId
                });
            }

            return comisionesResult;
        }

        public void ActivarUsuario(ActivacionUsuarioDTO usuarioDto)
        {
            var usuario = db.Usuarios.Single(u => u.Id == usuarioDto.UsuarioId);
            usuario.Password = usuarioDto.Password1;

            db.SaveChanges();
        }

        public List<PermisoUsuarioDTO> GetPermisosUsuario()
        {
            return db.Permisos.Select(p => new PermisoUsuarioDTO
            {
                PermisoId = p.Id,
                Nombre = p.Nombre,
                Checked = false
            }).ToList();
        }

        public List<ComisionAprobacionUsuarioDTO> GetComisionesAprobacion()
        {
            return db.ComisionesAprobacion.Select(c => new ComisionAprobacionUsuarioDTO
            {
                Checked = false,
                ComisionAprobacionId = c.Id,
                Nombre = c.Nombre,
                UsuarioCreacionId = 0,
                UsuarioId = 0
            }).ToList();
        }

        public string EnableResetPassword(int usuarioId)
        {
            var usuario = db.Usuarios.Single(u => u.Id == usuarioId);
            usuario.ChangePasswordCodeExpiration = DateTime.Now.AddHours(0.5);
            usuario.ChangePasswordCode = new Random().Next(1000, 9999).ToString();

            db.SaveChanges();
            
            return usuario.ChangePasswordCode;
        }

        public Usuario GetByIdAndChangePasswordCode(int usuarioId, string code)
        {
            return db.Usuarios.FirstOrDefault(u => u.Id == usuarioId
            && u.ChangePasswordCode == code
            && u.ChangePasswordCodeExpiration >= DateTime.Now);
        }

        public HttpDataResponse VerificarEmailExiste(CreacionUsuarioDTO usuarioDTO)
        {
            HttpDataResponse response = new HttpDataResponse();

            var usuario = db.Usuarios.FirstOrDefault(u => u.Email == usuarioDTO.Email && u.Disponible && (usuarioDTO.Id == 0));

            if (usuario != null)
            {
                response.AddError($"Ya existe un usuario con el email {usuarioDTO.Email} que pertenece a {usuario.NombreCompleto}");                
            }

            return response;
        }

        public Usuario Submit(CreacionUsuarioDTO usuarioDTO)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                Usuario usuario = null;

                if (usuarioDTO.Id > 0)
                {
                    usuario = db.Usuarios.Include(u => u.Maestro).Single(u => u.Id == usuarioDTO.Id);

                    if (usuario.Maestro == null)
                    {
                        usuario.Maestro = new Maestro();
                    }
                }
                else
                {
                    usuario = new Usuario();
                    usuario.Maestro = new Maestro();

                    
                }

                usuario.Maestro.Cedula = usuarioDTO.Cedula;
                usuario.Maestro.NombreCompleto = usuarioDTO.NombreCompleto;
                usuario.Maestro.Cargo = usuarioDTO.Cargo;
                usuario.Maestro.SeccionalId = usuarioDTO.SeccionalId;
                usuario.Maestro.Sexo = usuarioDTO.Sexo;
                usuario.Maestro.FechaNacimiento = usuarioDTO.FechaNacimiento;
                usuario.Maestro.Direccion = usuarioDTO.Direccion;

                usuario.Maestro.TelefonoCelular = usuarioDTO.TelefonoCelular;
                usuario.Maestro.TelefonoLabora = usuarioDTO.TelefonoLabora;
                usuario.Maestro.TelefonoResidencial = usuarioDTO.TelefonoResidencial;

                usuario.Login = usuarioDTO.Login;
                usuario.Email = usuarioDTO.Email;
                usuario.NombreCompleto = usuarioDTO.NombreCompleto;
                usuario.FechaCreacion = DateTime.Now;
                usuario.Disponible = false;
                usuario.FechaInactivacion = null;
                usuario.SeccionalId = usuarioDTO.SeccionalId;
                usuario.Disponible = usuarioDTO.Disponible;

                ActualizarPermisos(usuarioDTO);
                ActualizarComisiones(usuarioDTO);

                if (usuario.Id == 0)
                    db.Usuarios.Add(usuario);
                db.SaveChanges();
                scope.Complete();

                return usuario;
            }

        }

        private void ActualizarPermisos(CreacionUsuarioDTO usuarioDTO)
        {
            foreach (var item in usuarioDTO.PermisosUsuario)
            {
                var permisoUsuario = db.PermisosUsuarios.FirstOrDefault(pu => pu.UsuarioId == usuarioDTO.Id && pu.PermisoId == item.PermisoId);

                if (item.Checked)
                {
                    if (permisoUsuario == null)
                    {
                        db.PermisosUsuarios.Add(new PermisoUsuario
                        {
                            PermisoId = item.PermisoId,
                            UsuarioId = item.UsuarioId,
                            Disponible = true,
                        });
                    }
                    else if (permisoUsuario.Disponible == false)
                    {
                        permisoUsuario.Disponible = true;
                    }
                }
                else
                {
                    if (permisoUsuario != null)
                    {
                        permisoUsuario.Disponible = false;
                    }
                }
            }
        }

        private void ActualizarComisiones(CreacionUsuarioDTO usuarioDTO)
        {
            foreach (var item in usuarioDTO.ComisionesAprobacion)
            {
                var comisionAprobacionUsuario = db.UsuarioComisionAprobacion.FirstOrDefault(pu => pu.UsuarioId == usuarioDTO.Id && pu.ComisionAprobacionId == item.ComisionAprobacionId);

                if (item.Checked)
                {
                    if (comisionAprobacionUsuario == null)
                    {
                        db.UsuarioComisionAprobacion.Add(new UsuarioComisionAprobacion
                        {
                            ComisionAprobacionId = item.ComisionAprobacionId,
                            UsuarioId = item.UsuarioId,
                            UsuarioCreacionId = item.UsuarioId,
                            FechaCreacion = DateTime.Now,
                            Disponible = true
                        });
                    }
                    else if (comisionAprobacionUsuario.Disponible == false)
                    {
                        comisionAprobacionUsuario.Disponible = true;
                    }
                }
                else
                {
                    if (comisionAprobacionUsuario != null)
                    {
                        comisionAprobacionUsuario.Disponible = false;
                    }
                }
            }
        }
    }
}
