using Business.Core;
using Business.Model;
using Business.Model.ModelView;
using Data.Entity;
using Data.Repository.Model;
using System.Data.SqlTypes;

namespace Business
{
    public class MatriculaBusiness : CommonBusiness, IMatriculaCursoBusiness
    {
        private readonly IMatriculaCursoRepository _matriculaCursoRepository;

        public MatriculaBusiness(IMatriculaCursoRepository matriculaCursoRepository)
        {
            _matriculaCursoRepository = matriculaCursoRepository;
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
            try
            {
                var matricula = Map(matriculaModelView);

                _matriculaCursoRepository.Add(matricula);

                await _matriculaCursoRepository.SaveChangesAsync();
            }
            catch
            {
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
