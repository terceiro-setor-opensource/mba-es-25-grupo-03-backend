using Business.Model;
using Business.Model.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BaseAPI.Controllers
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
        [ProducesResponseType(200, Type = typeof(List<MensagemModelView>))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Get([Required] long idUsuario)
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ReponseModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post(MensagemModelView mensagemModelView)
        {
            try
            {
                await _mensagemBusiness.Add(mensagemModelView);

                return Response(null, _mensagemBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }
    }
}
