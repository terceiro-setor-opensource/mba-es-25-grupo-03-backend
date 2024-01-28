using Business.Model.ModelView;

namespace Business.Model
{
    public interface IMensagemBusiness : ICommonBusiness
    {
        Task<List<MensagemModelView>?> List(long idUsuario);

        Task Add(MensagemModelView mensagemModelView);
    }
}
