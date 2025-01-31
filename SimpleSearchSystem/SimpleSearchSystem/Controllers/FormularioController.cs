using Application.DTO.Request;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SimpleSearchSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1")]
    [Consumes("application/json")]
    [Produces("application/json")]
    public class FormularioController : ControllerBase
    {

        #region Construtor
        private readonly ILogger<FormularioController> _logger;
        private readonly FormularioService _formularioService;
        public FormularioController(FormularioService formularioService, ILogger<FormularioController> logger)
        {
            _formularioService = formularioService;
            _logger = logger;
        }
        #endregion

        [HttpGet("{Id}")]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterFormulario(int Id)
        {
            try
            {
                _logger.LogInformation($"Iniciando serviço - {nameof(ObterFormulario)}");

                var formulario = await _formularioService.ObterFormulario(Id);

                _logger.LogInformation($"Finalizado serviço - {nameof(ObterFormulario)}");

                return Ok(formulario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpGet]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> ObterFormularios(int NumeroPagina, int TamanhoPagina)
        {
            try
            {
                _logger.LogInformation($"Iniciando serviço - {nameof(ObterFormularios)}");

                var formulario = await _formularioService.ObterFormularios(NumeroPagina, TamanhoPagina);

                _logger.LogInformation($"Finalizado serviço - {nameof(ObterFormularios)}");

                return Ok(formulario);
            }
            catch (ArgumentException ex)
            {
                return StatusCode(400, ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarFormulario([FromBody] FormularioRequest request)
        {
            try
            {
                _logger.LogInformation($"Iniciando serviço - {nameof(CriarFormulario)}");

                await _formularioService.CriarFormulario(request);

                _logger.LogInformation($"Finalizado serviço - {nameof(CriarFormulario)}");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        [SwaggerResponse(StatusCodes.Status200OK)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> AtualizarFormulario([FromBody] EditFormularioRequest request)
        {
            try
            {
                _logger.LogInformation($"Iniciando serviço - {nameof(AtualizarFormulario)}");

                await _formularioService.AtualizarFormulario(request);

                _logger.LogInformation($"Finalizado serviço - {nameof(AtualizarFormulario)}");

                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

    }
}
