using Business.Model;
using Data.Entity;

namespace Data.Repository.Model
{
    public interface IMensagemMatriculaRepository : IRepository<MensagemMatricula>
    {
        Task<List<MensagemModelView>> ListaPorMatriculaUsuario(long idUsuario);
    }
}
