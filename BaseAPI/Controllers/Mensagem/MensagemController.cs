using Business.Model.ModelView;
using Business.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.Controllers.Mensagem
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Mensagem")]
    [Authorize("Bearer")]
    public class MensagemController : ApiController
    {
        private readonly IMensagemBusiness _mensagemBusiness;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mensagemBusiness"></param>
        public MensagemController(IMensagemBusiness mensagemBusiness)
        {
            _mensagemBusiness = mensagemBusiness;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CategoriaCursoModelView>))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Get(long idUsuario)
        {
            try
            {
                return Response(await _mensagemBusiness.List(idUsuario), _mensagemBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }
    }
}
