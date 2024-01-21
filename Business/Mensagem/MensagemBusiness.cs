using Business.Core;
using Business.Model;
using Data.Repository.Model;

namespace Business
{
    public class MensagemBusiness : CommonBusiness, IMensagemBusiness
    {
        private readonly IMensagemMatriculaRepository _mensagemMatriculaRepository;

        public MensagemBusiness(IMensagemMatriculaRepository mensagemMatriculaRepository)
        {
            _mensagemMatriculaRepository = mensagemMatriculaRepository;
        }

        public async Task<List<MensagemModelView>?> List(long idUsuario)
        {
            try
            {
                var listaMensagensPeloUsuario = await _mensagemMatriculaRepository.ListaPorMatriculaUsuario(idUsuario);

                if (listaMensagensPeloUsuario == null)
                {
                    Mensagem = "Categorias de cursos não encontrados";
                    return await Task.FromResult<List<MensagemModelView>?>(null);
                }

                return listaMensagensPeloUsuario;
            }
            catch
            {
                Mensagem = "Erro ao carregar lista de categorias de cursos";
                throw;
            }
        }
    }
}
