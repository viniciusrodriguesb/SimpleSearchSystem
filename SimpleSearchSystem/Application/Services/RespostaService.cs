using Application.DTO.Request;
using Domain;
using Infrasctructure.Data;

namespace Application.Services
{
    public class RespostaService
    {

        #region Construtor
        private readonly DbContextBase _context;
        public RespostaService(DbContextBase context)
        {
            _context = context;
        }
        #endregion

        public async Task ResponderPergunta(RespostaRequest request)
        {
            try
            {
                var formularioRespondido = new RESPOSTA_FORMULARIO()
                {
                    FormularioId = request.DadosFormulario.IdFormulario,
                    UsuarioId = request.DadosFormulario.IdUsuario,
                    DtResposta = DateTime.UtcNow
                };

                await _context.AddAsync(formularioRespondido);
                await _context.SaveChangesAsync();

                var opcoesRespondidas = request.DadosResposta
                                               .Select(r => new RESPOSTA_PERGUNTA()
                                               {
                                                   RespostaFormularioId = formularioRespondido.Id,
                                                   PerguntaId = r.IdPergunta,
                                                   OpcaoId = r.IdOpcao
                                               }).ToList();

                await _context.RESPOSTA_PERGUNTA.AddRangeAsync(opcoesRespondidas);
                await _context.SaveChangesAsync();

            }
            catch
            {
                throw;
            }
        }


    }
}
