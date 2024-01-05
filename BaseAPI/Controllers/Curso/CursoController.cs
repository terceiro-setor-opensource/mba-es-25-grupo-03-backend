using Business.Model;
using Business.Model.ModelView;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Curso")]
    [Authorize("Bearer")]
    public class CursoController : ApiController
    {
        private readonly ICursoBusiness _cursoBusiness;

        public CursoController(ICursoBusiness cursoBusiness)
        {
            _cursoBusiness = cursoBusiness;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CursoModelView>))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Response(await _cursoBusiness.List(), _cursoBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CursoModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Response(await _cursoBusiness.Get(id), _cursoBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CursoModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post([FromBody] CursoModelView curso)
        {
            try
            {
                await _cursoBusiness.Post(curso);

                return Response(null, _cursoBusiness.Mensagem, true);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(CursoModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post(int id, [FromBody] CursoModelView curso)
        {
            try
            {
                await _cursoBusiness.Put(id, curso);

                return Response(null, _cursoBusiness.Mensagem, true);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(CursoModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post(int id)
        {
            try
            {
                await _cursoBusiness.Delete(id);

                return Response(null, _cursoBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }
    }
}
