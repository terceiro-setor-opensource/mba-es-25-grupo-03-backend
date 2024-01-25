using Business.Core;
using Business.Model;
using Business.Model.ModelView;
using Data.Entity;
using Data.Repository.Model;

namespace Business
{
    public class ConteudoCursoBusiness : CommonBusiness, IConteudoCursoBusiness
    {

        private readonly IConteudoCursoRepository _conteudoCursoRepository;

        public ConteudoCursoBusiness(IConteudoCursoRepository conteudoCursoRepository)
        {
            _conteudoCursoRepository = conteudoCursoRepository;
        }

        public async Task<List<ConteudoCursoModelView>?> List(long idCurso)
        {
            try
            {
                var listaConteudoCurso = await _conteudoCursoRepository.ListAsNoTrackingAsync(x => x.IdCurso == idCurso);

                if (listaConteudoCurso == null)
                {
                    Mensagem = "Conteudos de cursos não encontrados";
                    return await Task.FromResult<List<ConteudoCursoModelView>?>(null);
                }

                return listaConteudoCurso.Select(Map).OrderBy(x => x.Ordem).ToList();
            }
            catch
            {
                Mensagem = "Erro ao carregar lista de conteudos de cursos";
                throw;
            }
        }

        public async Task<ConteudoCursoModelView?> Get(int id)
        {
            try
            {
                var conteudoCurso = await _conteudoCursoRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (conteudoCurso == null)
                {
                    Mensagem = "Conteudo de cursos não encontrado";
                    return await Task.FromResult<ConteudoCursoModelView?>(null);
                }

                return Map(conteudoCurso);
            }
            catch
            {
                Mensagem = "Erro ao carregar conteudo de cursos";
                throw;
            }
        }

        public async Task Post(ConteudoCursoModelView conteudoCursoModelView)
        {
            try
            {
                var conteudoCurso = Map(conteudoCursoModelView);

                _conteudoCursoRepository.Add(conteudoCurso);

                await _conteudoCursoRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao criar conteudo de cursos";
                throw;
            }
        }

        public async Task Put(int id, ConteudoCursoModelView conteudoCursoModelView)
        {
            try
            {
                var conteudoCurso = await _conteudoCursoRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (conteudoCurso == null)
                {
                    Mensagem = "Conteudo de cursos não encontrado";
                    return;
                }

                Map(ref conteudoCurso, conteudoCursoModelView);

                _conteudoCursoRepository.Update(conteudoCurso);

                await _conteudoCursoRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao alterar conteudo de cursos";
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var conteudoCurso = await _conteudoCursoRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (conteudoCurso == null)
                {
                    Mensagem = "Conteudo de cursos não encontrado";
                    return;
                }

                _conteudoCursoRepository.Delete(conteudoCurso);

                await _conteudoCursoRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao excluir conteudo de cursos";
                throw;
            }
        }

        #region Map

        private static ConteudoCursoModelView Map(ConteudoCurso conteudoCurso)
        {
            return new ConteudoCursoModelView
            {
                Id = conteudoCurso.Id,
                Descricao = conteudoCurso.Descricao,
                Ordem = conteudoCurso.NumeroOrdem,
                DuracaoMinutos = conteudoCurso.DuracaoMinutos,
                DuracaoFormatada = $"{(conteudoCurso.DuracaoMinutos / 60).ToString().PadLeft(2, '0')}:{(conteudoCurso.DuracaoMinutos % 60).ToString().PadLeft(2, '0')}",
                Informacoes = conteudoCurso.Informacoes,
                UrlVideo = conteudoCurso.UrlVideo
            };
        }

        private static ConteudoCurso Map(ConteudoCursoModelView conteudoCursoModelView)
        {
            return new ConteudoCurso
            {

            };
        }

        private static void Map(ref ConteudoCurso curso, ConteudoCursoModelView conteudoCursoModelView)
        {

        }

        #endregion
    }
}
