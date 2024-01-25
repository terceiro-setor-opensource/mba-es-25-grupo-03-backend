using Business.Model;
using Business.Model.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Notificacao")]
    [Authorize("Bearer")]
    public class NotificacaoController : ApiController
    {
        private readonly INotificacaoBusiness _notificacaoBusiness;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="notificacaoBusiness"></param>
        public NotificacaoController(INotificacaoBusiness notificacaoBusiness)
        {
            _notificacaoBusiness = notificacaoBusiness;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet("idUsuario")]
        [ProducesResponseType(200, Type = typeof(List<NotificacaoModelView>))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Get(long idUsuario)
        {
            try
            {
                return Response(await _notificacaoBusiness.List(idUsuario), _notificacaoBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(ReponseModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Put(long id)
        {
            try
            {
                await _notificacaoBusiness.Put(id);

                return Response(null, _notificacaoBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }
    }
}
