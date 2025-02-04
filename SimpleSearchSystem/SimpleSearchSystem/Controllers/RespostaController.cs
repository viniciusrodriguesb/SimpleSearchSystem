using Application.DTO.Request;
using Application.Services;
using Microsoft.AspNetCore.Mvc;

namespace SimpleSearchSystem.Controllers
{

    [ApiController]
    [Route("api/[controller]/v1")]
    public class RespostaController : ControllerBase
    {

        #region Construtor
        private readonly RespostaService _respostaService;
        private readonly ILogger<RespostaController> _logger;
        public RespostaController(RespostaService respostaService, ILogger<RespostaController> logger)
        {
            _logger = logger;
            _respostaService = respostaService;
        }
        #endregion

        [HttpPost]
        public async Task<IActionResult> ResponderPergunta([FromBody] RespostaRequest request)
        {
            try
            {
                _logger.LogInformation($"Iniciando serviço - {nameof(ResponderPergunta)}");

                await _respostaService.ResponderPergunta(request);

                _logger.LogInformation($"Finalizado serviço - {nameof(ResponderPergunta)}");

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
