using Business.Model.ModelView;
using Data.Entity;

namespace Data.Repository.Model
{
    public interface IMensagemRepository : IRepository<Mensagem>
    {
        Task<List<MensagemModelView>> ListPorUsuario(long idUsuario);
    }
}
