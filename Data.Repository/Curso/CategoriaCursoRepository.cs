using Data.Core;
using Data.Entity;
using Data.Repository.Model;

namespace Data.Repository
{
    public class CategoriaCursoRepository : Repository<CategoriaCurso>, ICategoriaCursoRepository
    {
        public CategoriaCursoRepository(IContext context)
            : base(context)
        {

        }
    }
}