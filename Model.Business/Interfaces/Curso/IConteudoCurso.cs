using Business.Model.ModelView;

namespace Business.Model
{
    public interface IConteudoCursoBusiness : ICommonBusiness
    {
        Task<List<ConteudoCursoModelView>?> List();

        Task<ConteudoCursoModelView?> Get(int id);

        Task Post(ConteudoCursoModelView model);

        Task Put(int id, ConteudoCursoModelView model);

        Task Delete(int id);
    }
}