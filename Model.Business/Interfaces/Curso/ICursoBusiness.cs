using Business.Model.ModelView;

namespace Business.Model
{
    public interface ICursoBusiness : ICommonBusiness
    {
        Task<List<CursoModelView>?> List(string? descricao, string? categorias, int ratingMin, int ratingMax, int duracaoMin, int duracaoMax);

        Task<CursoModelView?> Get(int id);

        Task Post(CursoModelView model);

        Task Put(int id, CursoModelView model);

        Task Delete(int id);
    }
}