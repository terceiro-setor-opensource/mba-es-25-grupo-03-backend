using Data.Core;
using Data.Entity;
using Data.Repository.Model;

namespace Data.Repository
{
    public class CursoRepository : Repository<Curso>, ICursoRepository
    {
        public CursoRepository(IContext context)
            : base(context)
        {

        }
    }
}