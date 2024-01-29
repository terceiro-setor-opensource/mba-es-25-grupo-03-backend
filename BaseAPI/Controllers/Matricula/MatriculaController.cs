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
    [ApiExplorerSettings(GroupName = "Matricula")]
    [Authorize("Bearer")]
    public class MatriculaController : ApiController
    {
        private readonly IMatriculaCursoBusiness _matriculaBusiness;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="matriculaBusiness"></param>
        public MatriculaController(IMatriculaCursoBusiness matriculaBusiness)
        {
            _matriculaBusiness = matriculaBusiness;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<MatriculaModelView>))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Get([Required] long idUsuario)
        {
            try
            {
                return Response(await _matriculaBusiness.List(idUsuario), _matriculaBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(200, Type = typeof(ReponseModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post(MatriculaModelView matriculaModelView)
        {
            try
            {
                await _matriculaBusiness.Add(matriculaModelView);

                return Response(null, _matriculaBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }
    }
}
