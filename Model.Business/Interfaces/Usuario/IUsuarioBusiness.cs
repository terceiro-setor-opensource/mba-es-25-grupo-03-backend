using Business.Model.ModelView;

namespace Business.Model
{
    public interface IUsuarioBusiness : ICommonBusiness
    {
        Task<List<UsuarioModelView>?> List();

        Task<UsuarioModelView?> Get(int id);

        Task Post(UsuarioModelView model);

        Task Put(int id, UsuarioModelView model);

        Task Delete(int id);
    }
}