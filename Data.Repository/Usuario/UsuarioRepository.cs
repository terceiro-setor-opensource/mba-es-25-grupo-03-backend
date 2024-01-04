using Data.Core;
using Data.Entity;
using Data.Repository.Model;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(IContext context)
            : base(context)
        {

        }

        public async Task<Usuario?> GetByLogin(string login)
        {
            return await Entity().AsNoTracking().FirstOrDefaultAsync(x => x.Documento == login || x.Email.ToUpper() == login.ToUpper());
        }
    }
}