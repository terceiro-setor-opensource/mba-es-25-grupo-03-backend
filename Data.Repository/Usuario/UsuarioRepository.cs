using Data.Core;
using Data.Entity;
using Data.Repository.Model;

namespace Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IContext context)
            : base(context)
        {

        }
    }
}