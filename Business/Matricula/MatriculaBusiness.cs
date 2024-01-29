using Business.Core;
using Business.Model;
using Business.Model.ModelView;
using Data.Repository.Model;

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
    }
}
