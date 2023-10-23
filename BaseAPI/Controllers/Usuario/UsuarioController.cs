﻿using Business.Model;
using Business.Model.ModelView;
using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Usuario")]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioBusiness _usuarioBusiness;

        public UsuarioController(IUsuarioBusiness usuarioBusiness)
        {
            _usuarioBusiness = usuarioBusiness;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(List<UsuarioModelView>))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Get()
        {
            try            
            {
                return Response(await _usuarioBusiness.List(), _usuarioBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(UsuarioModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                return Response(await _usuarioBusiness.Get(id), _usuarioBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(UsuarioModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post([FromBody] UsuarioModelView usuario)
        {
            try
            {
                await _usuarioBusiness.Post(usuario);

                return Response(null, _usuarioBusiness.Mensagem, true);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(200, Type = typeof(UsuarioModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post(int id, [FromBody] UsuarioModelView usuario)
        {
            try
            {
                await _usuarioBusiness.Put(id, usuario);

                return Response(null, _usuarioBusiness.Mensagem, true);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(200, Type = typeof(UsuarioModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post(int id)
        {
            try
            {
                await _usuarioBusiness.Delete(id);

                return Response(null, _usuarioBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }
    }
}
