using Business.Core;
using Business.Model;
using Business.Model.ModelView;
using Data.Entity;
using Data.Repository.Model;

namespace Business
{
    public class CursoBusiness : CommonBusiness, ICursoBusiness
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoBusiness(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<List<CursoModelView>?> List(string? descricao, long categoria = 0, int classificacao = 0, int duracaoMin = 0, int duracaoMax = 0)
        {
            try
            {
                var listaCursos = await _cursoRepository.ListaCursos(descricao, categoria, classificacao, duracaoMin, duracaoMax);

                if (listaCursos == null)
                {
                    Mensagem = "Cursos não encontrados";
                    return await Task.FromResult<List<CursoModelView>?>(null);
                }

                return listaCursos.Select(Map).ToList();
            }
            catch
            {
                Mensagem = "Erro ao carregar lista de Cursos";
                throw;
            }
        }

        public async Task<CursoModelView?> Get(int id)
        {
            try
            {
                var curso = await _cursoRepository.GetCurso(id);

                if (curso == null)
                {
                    Mensagem = "Curso não encontrado";
                    return await Task.FromResult<CursoModelView?>(null);
                }

                return Map(curso);
            }
            catch
            {
                Mensagem = "Erro ao carregar Curso";
                throw;
            }
        }

        public async Task Post(CursoModelView cursoModelView)
        {
            try
            {
                var curso = Map(cursoModelView);

                _cursoRepository.Add(curso);

                await _cursoRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao criar Curso";
                throw;
            }
        }

        public async Task Put(int id, CursoModelView cursoModelView)
        {
            try
            {
                var curso = await _cursoRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (curso == null)
                {
                    Mensagem = "Curso não encontrado";
                    return;
                }

                Map(ref curso, cursoModelView);

                _cursoRepository.Update(curso);

                await _cursoRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao alterar Curso";
                throw;
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var curso = await _cursoRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (curso == null)
                {
                    Mensagem = "Curso não encontrado";
                    return;
                }

                _cursoRepository.Delete(curso);

                await _cursoRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao excluir Curso";
                throw;
            }
        }

        #region Map

        private static CursoModelView Map(Curso curso) => new()
        {
            Id = curso.Id,
            Descricao = curso.Nome,
            Usuario = new UsuarioModelView
            {
                Nome = curso.Usuario.Nome,
            },
            Categoria = new CategoriaCursoModelView
            {
                Id = curso.CategoriaCurso.Id,
                Descricao = curso.CategoriaCurso.Nome,
                Avatar = curso.CategoriaCurso.Avatar != null ? Convert.ToBase64String(curso.CategoriaCurso.Avatar) : string.Empty
            },
            Informacoes = curso.Informacoes,
            DuracaoMinutos = curso.ConteudoCurso.Sum(x => x.MinutosDuracao),
            DataCriacao = curso.DataCriacao,
            //PreRequisito = ,
            Obrigatorio = curso.PreRequisitoObrigatorio != 0,
            Avatar = curso.Avatar != null ? Convert.ToBase64String(curso.Avatar) : string.Empty,
            Conteudo = curso.ConteudoCurso.OrderBy(x => x.NumeroOrdem).Select(i => new ConteudoCursoModelView
            {
                Id = i.Id, 
                Descricao = i.Nome, 
                Ordem = i.NumeroOrdem, 
                Duracao = i.MinutosDuracao, 
                Informacoes = i.Informacoes,
                UrlVideo = i.UrlVideo
            }).ToList()
        };

        private static Curso Map(CursoModelView cursoModelView)
        {
            return new Curso
            {
                Nome = cursoModelView.Descricao,
                IdUsuario = cursoModelView.Usuario.Id,
                IdCategoriaCurso = cursoModelView.Categoria.Id,
                Informacoes = cursoModelView.Informacoes,
                //IdPreRequisito = cursoModelView.PreRequisito.Id,
                PreRequisitoObrigatorio = 0,
                Avatar = cursoModelView.Avatar != null ? Convert.FromBase64String(cursoModelView.Avatar) : default,
                Classificacao = cursoModelView.Classificacao,
                DataCriacao = DateTime.Now
            };
        }

        private static void Map(ref Curso curso, CursoModelView cursoModelView)
        {
            //curso.Avatar = curso.Avatar! != Convert.FromBase64String(cursoModelView.Avatar) ? Convert.FromBase64String(cursoModelView.Avatar) : curso.Avatar!;
        }

        #endregion
    }
}
