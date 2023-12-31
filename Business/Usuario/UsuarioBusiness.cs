﻿using Business.Core;
using Business.Model;
using Business.Model.ModelView;
using Data.Entity;
using Data.Repository.Model;
using Infra;

namespace Business
{
    public class UsuarioBusiness : CommonBusiness, IUsuarioBusiness
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioBusiness(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<UsuarioModelView>?> List()
        {
            try
            {
                var listaUsuario = await _usuarioRepository.ListAsNoTrackingAsync();

                if (listaUsuario == null)
                {
                    Mensagem = "Usuários não encontrados";
                    return await Task.FromResult<List<UsuarioModelView>?>(null);
                }

                return listaUsuario.Select(Map).ToList();
            }
            catch
            {
                Mensagem = "Erro ao carregar lista de usuários";
                throw;
            }
        }

        public async Task<UsuarioModelView?> Get(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (usuario == null)
                {
                    Mensagem = "Usuário não encontrado";
                    return await Task.FromResult<UsuarioModelView?>(null);
                }

                return Map(usuario);
            }
            catch
            {
                Mensagem = "Erro ao carregar usuário";
                throw;
            }
        }

        public async Task Post(UsuarioModelView usuarioModelView)
        {
            try
            {
                var usuario = Map(usuarioModelView);

                _usuarioRepository.Add(usuario);

                await _usuarioRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao criar usuário";
                throw;
            }
        }

        public async Task Put(int id, UsuarioModelView usuarioModelView)
        {
            try
            {
                var usuario = await _usuarioRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (usuario == null)
                {
                    Mensagem = "Usuário não encontrado";
                    return;
                }

                Map(ref usuario, usuarioModelView);

                _usuarioRepository.Update(usuario);

                await _usuarioRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao alterar usuário";
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var usuario = await _usuarioRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (usuario == null)
                {
                    Mensagem = "Usuário não encontrado";
                    return;
                }

                _usuarioRepository.Delete(usuario);

                await _usuarioRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao excluir usuário";
                throw;
            }
        }

        #region Map

        private static UsuarioModelView Map(Usuario usuario)
        {
            return new UsuarioModelView
            {
                Id = usuario.Id, 
                Nome = usuario.Nome,
                Documento = usuario.Documento,
                Email = usuario.Email
            };
        }

        private static Usuario Map(UsuarioModelView usuarioModelView)
        {
            return new Usuario
            {
                Nome = usuarioModelView.Nome,
                Documento = usuarioModelView.Documento,
                Senha = Utils.GetHash(usuarioModelView.Senha!),
                Email = usuarioModelView.Email
            };
        }

        private static void Map(ref Usuario usuario, UsuarioModelView usuarioModelView)
        {
            usuario.Nome = usuario.Nome! != usuarioModelView.Nome! ? usuarioModelView.Nome! : usuario.Nome!;
            usuario.Senha = usuario.Senha! != Utils.GetHash(usuarioModelView.Senha!) ? Utils.GetHash(usuarioModelView.Senha!) : usuario.Senha!;
            usuario.Email = usuario.Email! != usuarioModelView.Email! ? usuarioModelView.Email! : usuario.Email!;
        }

        #endregion
    }
}