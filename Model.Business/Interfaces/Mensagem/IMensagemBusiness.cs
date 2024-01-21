namespace Business.Model
{
    public interface IMensagemBusiness : ICommonBusiness
    {
        Task<List<MensagemModelView>> List(long idUsuario);
    }
}
