using Microsoft.AspNetCore.Mvc;

namespace BaseAPI
{
    /// <summary>
    /// 
    /// </summary>
    public class ApiController : Controller
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="dados"></param>
        /// <param name="mensagem"></param>
        /// <param name="addOrUpdate"></param>
        /// <returns></returns>
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
