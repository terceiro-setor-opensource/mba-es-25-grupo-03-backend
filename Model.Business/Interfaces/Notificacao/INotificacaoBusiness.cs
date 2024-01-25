namespace Business.Model
{
    public interface INotificacaoBusiness : ICommonBusiness
    {
        Task<List<NotificacaoModelView>> List(long idUsuario);

        Task Put(long id);
    }
}
