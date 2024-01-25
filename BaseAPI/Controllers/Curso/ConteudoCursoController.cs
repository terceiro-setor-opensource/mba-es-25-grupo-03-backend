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
    [ApiExplorerSettings(GroupName = "Curso")]
    [Authorize("Bearer")]
    public class ConteudoCursoController : ApiController
    {
        private readonly IConteudoCursoBusiness _conteudoCursoBusiness;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conteudoCursoBusiness"></param>
        public ConteudoCursoController(IConteudoCursoBusiness conteudoCursoBusiness)
        {
            _conteudoCursoBusiness = conteudoCursoBusiness;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        [ProducesResponseType(200, Type = typeof(List<ConteudoCursoModelView>))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Get([Required] long idCurso)
        {
            try
            {
                return Response(await _conteudoCursoBusiness.List(idCurso), _conteudoCursoBusiness.Mensagem, false);
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
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(ConteudoCursoModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Response(await _conteudoCursoBusiness.Get(id), _conteudoCursoBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conteudoCurso"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ConteudoCursoModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post([FromBody] ConteudoCursoModelView conteudoCurso)
        {
            try
            {
                await _conteudoCursoBusiness.Post(conteudoCurso);

                return Response(null, _conteudoCursoBusiness.Mensagem, true);
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
        /// <param name="conteudoCurso"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(ConteudoCursoModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post(int id, [FromBody] ConteudoCursoModelView conteudoCurso)
        {
            try
            {
                await _conteudoCursoBusiness.Put(id, conteudoCurso);

                return Response(null, _conteudoCursoBusiness.Mensagem, true);
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
        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(ConteudoCursoModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post(int id)
        {
            try
            {
                await _conteudoCursoBusiness.Delete(id);

                return Response(null, _conteudoCursoBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }
    }
}
