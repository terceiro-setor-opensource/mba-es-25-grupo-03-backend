using Data.Entity;

namespace Data.Repository.Model
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Task<List<Curso>?> ListaCursos(string? descricao, long categoria = 0, int classificacao = 0, int duracaoMin = 0, int duracaoMax = 0);

        Task<Curso?> GetCurso(long id);
    }
}
