using Microsoft.AspNetCore.Mvc;

namespace BaseAPI
{
    public class ApiController : Controller
    {
        protected new IActionResult Response(object? dados, string? mensagem, bool addOrUpdate)
        {
            if (string.IsNullOrWhiteSpace(mensagem))
            {
                if (!addOrUpdate)
                {
                    if (dados != null)
                    {
                        return Ok(dados);
                    }

                    return Ok(new ReponseModelView());
                }

                return Created("", new ReponseModelView());
            }
            else
            {
                if (!addOrUpdate)
                {
                    return NotFound(new ReponseModelView(mensagem));
                }

                return BadRequest(new ReponseModelView(mensagem));
            }
        }
    }
}
