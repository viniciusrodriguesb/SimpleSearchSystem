using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace SimpleSearchSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class FormularioController : ControllerBase
    {
        private readonly FormularioService _formularioService;
        public FormularioController(FormularioService formularioService)
        {
            _formularioService = formularioService;
        }


        [HttpGet("/{Id}")]
        public async Task<IActionResult> ObterFormulario(int Id)
        {
            try
            {

                var formulario = await _formularioService.ObterFormulario(Id);

                return Ok(formulario);

            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
