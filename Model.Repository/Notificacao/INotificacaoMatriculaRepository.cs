using Business.Model;
using Data.Entity;

namespace Data.Repository.Model
{
    public interface INotificacaoMatriculaRepository : IRepository<NotificacaoMatricula>
    {
        Task<List<NotificacaoModelView>> ListaPorMatriculaUsuario(long idUsuario);
    }
}
