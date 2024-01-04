using Business.Model.ModelView;

namespace Business.Model
{
    public interface ILoginBusiness : ICommonBusiness
    {
        Task<LoginResponseModelView?> Authenticate(LoginModelView loginModelView);
    }
}
