using Business.Core;
using Business.Model;
using Business.Model.ModelView;
using Data.Entity;
using Data.Repository.Model;
using Infra;
using Microsoft.AspNetCore.Http;

namespace Business
{
    public class CategoriaCursoBusiness : CommonBusiness, ICategoriaCursoBusiness
    {
        private readonly ICategoriaCursoRepository _categoriaCursoRepository;

        public CategoriaCursoBusiness(ICategoriaCursoRepository categoriaCursoRepository)
        {
            _categoriaCursoRepository = categoriaCursoRepository;
        }

        public async Task<List<CategoriaCursoModelView>?> List()
        {
            try
            {
                var listaCategoriaCurso = await _categoriaCursoRepository.ListAsNoTrackingAsync();

                if (listaCategoriaCurso == null)
                {
                    Mensagem = "Categorias de cursos não encontrados";
                    return await Task.FromResult<List<CategoriaCursoModelView>?>(null);
                }

                return listaCategoriaCurso.Select(Map).ToList();
            }
            catch
            {
                Mensagem = "Erro ao carregar lista de categorias de cursos";
                throw;
            }
        }

        public async Task<CategoriaCursoModelView?> Get(int id)
        {
            try
            {
                var categoriaCurso = await _categoriaCursoRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (categoriaCurso == null)
                {
                    Mensagem = "Categoria de cursos não encontrado";
                    return await Task.FromResult<CategoriaCursoModelView?>(null);
                }

                return Map(categoriaCurso);
            }
            catch
            {
                Mensagem = "Erro ao carregar categoria de cursos";
                throw;
            }
        }

        public async Task Post(string descricao, IFormFile avatar)
        {
            try
            {
                var categoriaCurso = Map(descricao, await Utils.ConvertIFormFileToByteArray(avatar));

                _categoriaCursoRepository.Add(categoriaCurso);

                await _categoriaCursoRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao criar categoria de cursos";
                throw;
            }
        }

        public async Task Put(int id, string descricao, IFormFile avatar)
        {
            try
            {
                var categoriaCurso = await _categoriaCursoRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (categoriaCurso == null)
                {
                    Mensagem = "Categoria de cursos não encontrado";
                    return;
                }

                Map(ref categoriaCurso, descricao, await Utils.ConvertIFormFileToByteArray(avatar));

                _categoriaCursoRepository.Update(categoriaCurso);

                await _categoriaCursoRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao alterar categoria de cursos";
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var categoriaCurso = await _categoriaCursoRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (categoriaCurso == null)
                {
                    Mensagem = "Categoria de cursos não encontrado";
                    return;
                }

                _categoriaCursoRepository.Delete(categoriaCurso);

                await _categoriaCursoRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao excluir categoria de cursos";
                throw;
            }
        }

        #region Map

        private static CategoriaCursoModelView Map(CategoriaCurso categoriaCurso)
        {
            return new CategoriaCursoModelView
            {
                Id = categoriaCurso.Id, 
                Descricao = categoriaCurso.Nome
            };
        }

        private static CategoriaCurso Map(string descricao, byte[] avatar)
        {
            return new CategoriaCurso
            {
                Nome = descricao,
                Avatar = avatar
            };
        }

        private static void Map(ref CategoriaCurso curso, string descricao, byte[] avatar)
        {
            curso.Nome = curso.Nome != descricao ? descricao : curso.Nome;
            curso.Avatar = curso.Avatar != avatar ? avatar : curso.Avatar;
        }

        #endregion
    }
}
