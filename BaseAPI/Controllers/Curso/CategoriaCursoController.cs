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
    public class CategoriaCursoController : ApiController
    {
        private readonly ICategoriaCursoBusiness _categoriaCursoBusiness;

        public CategoriaCursoController(ICategoriaCursoBusiness categoriaCursoBusiness)
        {
            _categoriaCursoBusiness = categoriaCursoBusiness;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<CategoriaCursoModelView>))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Get()
        {
            try
            {
                return Response(await _categoriaCursoBusiness.List(), _categoriaCursoBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(CategoriaCursoModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Response(await _categoriaCursoBusiness.Get(id), _categoriaCursoBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(CategoriaCursoModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post([FromBody] CategoriaCursoModelView categoriaCurso)
        {
            try
            {
                await _categoriaCursoBusiness.Post(categoriaCurso);

                return Response(null, _categoriaCursoBusiness.Mensagem, true);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(CategoriaCursoModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post(int id, [FromBody] CategoriaCursoModelView categoriaCurso)
        {
            try
            {
                await _categoriaCursoBusiness.Put(id, categoriaCurso);

                return Response(null, _categoriaCursoBusiness.Mensagem, true);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(CategoriaCursoModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post(int id)
        {
            try
            {
                await _categoriaCursoBusiness.Delete(id);

                return Response(null, _categoriaCursoBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }
    }
}
