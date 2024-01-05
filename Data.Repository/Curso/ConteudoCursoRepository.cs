using Data.Core;
using Data.Entity;
using Data.Repository.Model;

namespace Data.Repository
{
    public class ConteudoCursoRepository : Repository<ConteudoCurso>, IConteudoCursoRepository
    {
        public ConteudoCursoRepository(IContext context)
            : base(context)
        {

        }
    }
}