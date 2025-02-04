using Application.DTO.Request;
using Domain;
using Infrasctructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class PerguntaService
    {

        #region Construtor
        private readonly DbContextBase _context;
        public PerguntaService(DbContextBase context)
        {
            _context = context;
        }
        #endregion

        public async Task CriarPerguntas(PerguntaRequest request)
        {
            try
            {
                var existeFormulario = await _context.FORMULARIO
                                                     .Where(x => x.Id == request.FormularioId)
                                                     .Select(x => x.Id)
                                                     .FirstOrDefaultAsync();

                if (existeFormulario <= 0)
                    throw new ArgumentException("Não foi possível prosseguir, formulário inexistente.");

                var pergunta = new PERGUNTA()
                {
                    FormularioId = existeFormulario,
                    TextoPergunta = request.Pergunta,
                    Ordem = request.Ordem
                };

                await _context.PERGUNTA.AddAsync(pergunta);
                await _context.SaveChangesAsync();

                var opcoes = request.OpcoesRespostas
                                    .Select(op => new OPCAO_PERGUNTA()
                                    {
                                        PerguntaId = pergunta.Id,
                                        Ordem = op.Ordem,
                                        Texto = op.TextoOpcao
                                    }).ToList();

                await _context.OPCAO_PERGUNTA.AddRangeAsync(opcoes);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task EditarPergunta()
        {
            try
            {
                await Task.Delay(1000);
            }
            catch (Exception)
            {

            }
        }

        public async Task DeletarPergunta(int Id)
        {
            if (Id <= 0)
                throw new ArgumentException("Id solicitado não suportado, verifique e tente novamente");

            try
            {
                await _context.PERGUNTA.Where(x => x.Id == Id)
                                       .ExecuteDeleteAsync();
            }
            catch
            {
                throw;
            }
        }

    }
}
