using Business.Core;
using Business.Model;
using Business.Model.ModelView;
using Data.Entity;
using Data.Repository.Model;
using System.Data.SqlTypes;

namespace Business
{
    public class MensagemBusiness : CommonBusiness, IMensagemBusiness
    {
        private readonly IMensagemRepository _mensagemRepository;

        public MensagemBusiness(IMensagemRepository mensagemRepository)
        {
            _mensagemRepository = mensagemRepository;
        }

        public async Task<List<MensagemModelView>?> List(long idUsuario)
        {
            try
            {
                var listaMensagens = await _mensagemRepository.ListPorUsuario(idUsuario);

                if (listaMensagens == null)
                {
                    Mensagem = "Mensagens não encontradas";
                    return await Task.FromResult<List<MensagemModelView>?>(null);
                }

                return listaMensagens;
            }
            catch
            {
                Mensagem = "Erro ao carregar lista de mensagens";
                throw;
            }
        }

        public async Task Add(MensagemModelView mensagemModelView)
        {
            try
            {
                var mensagem = Map(mensagemModelView);

                await MarcaAnterioresComoLidas(mensagemModelView);

                _mensagemRepository.Add(mensagem);

                await _mensagemRepository.SaveChangesAsync();
            }
            catch
            {
                Mensagem = "Erro ao responder mensagem";
                throw;
            }
        }

        private async Task MarcaAnterioresComoLidas(MensagemModelView mensagemModelView)
        {
            var mensagensAnteriores = await _mensagemRepository.ListAsync(x => x.IdMatriculaCurso == mensagemModelView.IdMatricula && x.Instrutor == 1);

            if (mensagensAnteriores == null || mensagensAnteriores.Count == 0)
            {
                return;
            }

            foreach (var mensagemAnterior in mensagensAnteriores)
            {
                mensagemAnterior.Lida = 1;

                _mensagemRepository.Update(mensagemAnterior);
            }
        }

        #region Map

        private static Mensagem Map(MensagemModelView mensagemModelView)
        {
            return new Mensagem
            {
                IdMatriculaCurso = mensagemModelView.IdMatricula,                
                Texto = mensagemModelView.Mensagem,
                DataEnvio = SqlDateTime.MinValue.Value,
                Instrutor = 0,
                Lida = 0
            };
        }

        #endregion
    }
}
