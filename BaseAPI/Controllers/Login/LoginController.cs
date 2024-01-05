using Business.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BaseAPI.Controllers.Login
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "Login")]
    [AllowAnonymous]
    public class LoginController : ApiController
    {
        private readonly ILoginBusiness _loginBusiness;

        public LoginController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [ProducesResponseType(200, Type = typeof(LoginResponseModelView))]
        [ProducesResponseType(400, Type = typeof(ReponseModelView))]
        [ProducesResponseType(404, Type = typeof(ReponseModelView))]
        public async Task<IActionResult> Post([FromBody] LoginModelView usuario)
        {
            try
            {
                return Response(await _loginBusiness.Authenticate(usuario), _loginBusiness.Mensagem, false);
            }
            catch (Exception)
            {
                return StatusCode(500, null);
            }
        }
    }
}
