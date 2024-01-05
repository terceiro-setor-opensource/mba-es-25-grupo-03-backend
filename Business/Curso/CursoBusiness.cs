using Business.Core;
using Business.Model;
using Business.Model.ModelView;
using Data.Entity;
using Data.Repository.Model;
using Infra;

namespace Business
{
    public class CursoBusiness : CommonBusiness, ICursoBusiness
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoBusiness(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<List<CursoModelView>?> List()
        {
            try
            {
                var listaCurso = await _cursoRepository.ListAsNoTrackingAsync();

                if (listaCurso == null)
                {
                    Mensagem = "Cursos não encontrados";
                    return await Task.FromResult<List<CursoModelView>?>(null);
                }

                return listaCurso.Select(Map).ToList();
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
                var Curso = await _cursoRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (Curso == null)
                {
                    Mensagem = "Curso não encontrado";
                    return await Task.FromResult<CursoModelView?>(null);
                }

                return Map(Curso);
            }
            catch
            {
                Mensagem = "Erro ao carregar Curso";
                throw;
            }
        }

        public async Task Post(CursoModelView CursoModelView)
        {
            try
            {
                var Curso = Map(CursoModelView);

                _cursoRepository.Add(Curso);

                await _cursoRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao criar Curso";
                throw;
            }
        }

        public async Task Put(int id, CursoModelView CursoModelView)
        {
            try
            {
                var Curso = await _cursoRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (Curso == null)
                {
                    Mensagem = "Curso não encontrado";
                    return;
                }

                Map(ref Curso, CursoModelView);

                _cursoRepository.Update(Curso);

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
                var Curso = await _cursoRepository.GetAsNoTrackingAsync(x => x.Id == id);

                if (Curso == null)
                {
                    Mensagem = "Curso não encontrado";
                    return;
                }

                _cursoRepository.Delete(Curso);

                await _cursoRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao excluir Curso";
                throw;
            }
        }

        #region Map

        private static CursoModelView Map(Curso Curso)
        {
            return new CursoModelView
            {
                Id = Curso.Id
            };
        }

        private static Curso Map(CursoModelView CursoModelView)
        {
            return new Curso
            {
                
            };
        }

        private static void Map(ref Curso Curso, CursoModelView CursoModelView)
        {
            /*Curso.Nome = Curso.Nome! != CursoModelView.Nome! ? CursoModelView.Nome! : Curso.Nome!;
            Curso.Senha = Curso.Senha! != Utils.GetHash(CursoModelView.Senha!) ? Utils.GetHash(CursoModelView.Senha!) : Curso.Senha!;
            Curso.Email = Curso.Email! != CursoModelView.Email! ? CursoModelView.Email! : Curso.Email!;*/
        }

        #endregion
    }
}
