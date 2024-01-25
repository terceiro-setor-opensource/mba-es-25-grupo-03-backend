using Business.Core;
using Business.Model;
using Data.Repository.Model;

namespace Business
{
    public class NotificacaoBusiness : CommonBusiness, INotificacaoBusiness
    {
        private readonly INotificacaoMatriculaRepository _notificacaoMatriculaRepository;

        public NotificacaoBusiness(INotificacaoMatriculaRepository notificacaoMatriculaRepository)
        {
            _notificacaoMatriculaRepository = notificacaoMatriculaRepository;
        }

        public async Task<List<NotificacaoModelView>?> List(long idUsuario)
        {
            try
            {
                var listaNotificacaoPeloUsuario = await _notificacaoMatriculaRepository.ListaPorMatriculaUsuario(idUsuario);

                if (listaNotificacaoPeloUsuario == null)
                {
                    Mensagem = "Notificações não encontradas";
                    return await Task.FromResult<List<NotificacaoModelView>?>(null);
                }

                return listaNotificacaoPeloUsuario;
            }
            catch
            {
                Mensagem = "Erro ao carregar lista de notificações";
                throw;
            }
        }

        public async Task Put(long id)
        {
            try
            {
                var mensagem = await _notificacaoMatriculaRepository.GetAsync(x => x.Id == id);

                if (mensagem == null)
                {
                    Mensagem = "Notificação não encontrados";
                    return;
                }

                mensagem.Lida = 1;

                _notificacaoMatriculaRepository.Update(mensagem);

                await _notificacaoMatriculaRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao marcar notificação como lida";
                throw;
            }
        }
    }
}
