using Business.Model.ModelView;

namespace Business.Model
{
    public interface ICursoBusiness : ICommonBusiness
    {
        Task<List<CursoModelView>?> List();

        Task<CursoModelView?> Get(int id);

        Task Post(CursoModelView model);

        Task Put(int id, CursoModelView model);

        Task Delete(int id);
    }
}