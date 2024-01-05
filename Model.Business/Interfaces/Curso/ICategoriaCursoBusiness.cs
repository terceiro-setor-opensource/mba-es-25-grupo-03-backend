using Business.Model.ModelView;

namespace Business.Model
{
    public interface ICategoriaCursoBusiness : ICommonBusiness
    {
        Task<List<CategoriaCursoModelView>?> List();

        Task<CategoriaCursoModelView?> Get(int id);

        Task Post(CategoriaCursoModelView model);

        Task Put(int id, CategoriaCursoModelView model);

        Task Delete(int id);
    }
}