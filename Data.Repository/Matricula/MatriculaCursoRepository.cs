using Data.Core;
using Data.Entity;
using Data.Repository.Model;

namespace Data.Repository
{
    public class MatriculaCursoRepository : Repository<MatriculaCurso>, IMatriculaCursoRepository
    {
        public MatriculaCursoRepository(IContext context)
            : base(context)
        {

        }
    }
}
