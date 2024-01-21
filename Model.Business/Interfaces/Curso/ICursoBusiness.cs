using Business.Model.ModelView;

namespace Business.Model
{
    public interface ICursoBusiness : ICommonBusiness
    {
        Task<List<CursoModelView>?> List(string? descricao, long categoria = 0, int classificacao = 0, int duracaoMin = 0, int duracaoMax = 0);

        Task<CursoModelView?> Get(int id);

        Task Post(CursoModelView model);

        Task Put(int id, CursoModelView model);

        Task Delete(int id);
    }
}