using Data.Core;
using Data.Entity;
using Data.Repository.Model;

namespace Data.Repository
{
    public class MensagemCursoRepository : Repository<MensagemCurso>, IMensagemCursoRepository
    {
        public MensagemCursoRepository(IContext context)
            : base(context)
        {

        }
    }
}
