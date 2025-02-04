using Application.DTO.Request;
using Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace SimpleSearchSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]/v1")]
    public class PerguntaController : ControllerBase
    {

        private readonly ILogger<PerguntaController> _logger;
        private readonly PerguntaService _perguntaService;
        public PerguntaController(PerguntaService perguntaService, ILogger<PerguntaController> logger)
        {
            _perguntaService = perguntaService;
            _logger = logger;
        }

        [HttpPost]
        [SwaggerResponse(StatusCodes.Status201Created)]
        [SwaggerResponse(StatusCodes.Status400BadRequest)]
        [SwaggerResponse(StatusCodes.Status401Unauthorized)]
        [SwaggerResponse(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> CriarPerguntas([FromBody] PerguntaRequest request)
        {
            try
            {
                _logger.LogInformation($"Iniciando serviço - {nameof(CriarPerguntas)}");

                await _perguntaService.CriarPerguntas(request);

                _logger.LogInformation($"Finalizado serviço - {nameof(CriarPerguntas)}");

                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro de serviço: {ex.Message}");
                return StatusCode(500, ex.Message);
            }
        }

    }
}
