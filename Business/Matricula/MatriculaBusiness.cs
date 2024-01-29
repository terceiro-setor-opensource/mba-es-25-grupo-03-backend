using Business.Core;
using Business.Model;
using Business.Model.ModelView;
using Data.Entity;
using Data.Repository.Model;

namespace Business
{
    public class MatriculaBusiness : CommonBusiness, IMatriculaCursoBusiness
    {
        private readonly IMatriculaCursoRepository _matriculaCursoRepository;
        private readonly INotificacaoCursoRepository _notificacaoCursoRepository;
        private readonly INotificacaoMatriculaRepository _notificacaoMatriculaRepository;

        public MatriculaBusiness(IMatriculaCursoRepository matriculaCursoRepository,
                                 INotificacaoCursoRepository notificacaoCursoRepository,
                                 INotificacaoMatriculaRepository notificacaoMatriculaRepository)
        {
            _matriculaCursoRepository = matriculaCursoRepository;
            _notificacaoCursoRepository = notificacaoCursoRepository;
            _notificacaoMatriculaRepository = notificacaoMatriculaRepository;
        }

        public async Task<List<MatriculaModelView>?> List(long idUsuario)
        {
            try
            {
                var listaMatriculas = await _matriculaCursoRepository.ListPorUsuario(idUsuario);

                if (listaMatriculas == null)
                {
                    Mensagem = "Matrículas não encontradas";
                    return await Task.FromResult<List<MatriculaModelView>?>(null);
                }

                return listaMatriculas;
            }
            catch
            {
                Mensagem = "Erro ao carregar lista de matrículas";
                throw;
            }
        }

        public async Task Add(MatriculaModelView matriculaModelView)
        {
            var listaNotificacoesPorCurso = await _notificacaoCursoRepository.ListAsNoTrackingAsync(x => x.IdCurso == matriculaModelView.IdCurso);

            try
            {
                var matricula = Map(matriculaModelView);

                _matriculaCursoRepository.BeginTransaction();

                _matriculaCursoRepository.Add(matricula);

                await _matriculaCursoRepository.SaveChangesAsync();

                _notificacaoMatriculaRepository.Add(new NotificacaoMatricula
                {
                    IdMatricula = matricula.Id,
                    IdNotificacaoCurso = listaNotificacoesPorCurso.First(x => x.Icone == "sell").Id,
                    Lida = 0
                });

                _notificacaoMatriculaRepository.Add(new NotificacaoMatricula
                {
                    IdMatricula = matricula.Id,
                    IdNotificacaoCurso = listaNotificacoesPorCurso.First(x => x.Icone == "group").Id,
                    Lida = 0
                });

                await _notificacaoMatriculaRepository.SaveChangesAsync();

                _matriculaCursoRepository.Commit();
            }
            catch (Exception ex) 
            {
                _matriculaCursoRepository.Rollback();

                Mensagem = "Erro ao responder mensagem";
                throw;
            }
        }

        #region Map

        private static MatriculaCurso Map(MatriculaModelView mensagemModelView)
        {
            return new MatriculaCurso
            {
                IdUsuario = mensagemModelView.IdUsuario,
                IdCurso = mensagemModelView.IdCurso
            };
        }

        #endregion
    }
}
