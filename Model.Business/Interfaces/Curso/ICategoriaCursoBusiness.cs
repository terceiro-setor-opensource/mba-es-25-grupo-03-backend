using Business.Model.ModelView;
using Microsoft.AspNetCore.Http;

namespace Business.Model
{
    public interface ICategoriaCursoBusiness : ICommonBusiness
    {
        Task<List<CategoriaCursoModelView>?> List();

        Task<CategoriaCursoModelView?> Get(int id);

        Task Post(string descricao, IFormFile avatar);

        Task Put(int id, string descricao, IFormFile avatar);

        Task Delete(int id);
    }
}