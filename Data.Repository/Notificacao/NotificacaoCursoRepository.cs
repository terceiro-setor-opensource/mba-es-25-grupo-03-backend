using Data.Core;
using Data.Entity;
using Data.Repository.Model;

namespace Data.Repository
{
    public class NotificacaoCursoRepository : Repository<NotificacaoCurso>, INotificacaoCursoRepository
    {
        public NotificacaoCursoRepository(IContext context)
            : base(context)
        {

        }
    }
}
