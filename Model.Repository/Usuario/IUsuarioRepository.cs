using Data.Entity;

namespace Data.Repository.Model
{
    public interface IUsuarioRepository : IRepository<Usuario>
    {
        Task<Usuario?> GetByLogin(string login);
    }
}
