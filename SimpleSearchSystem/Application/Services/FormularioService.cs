using Application.DTO.Request;
using Application.DTO.Response;
using Domain;
using Infrasctructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class FormularioService
    {
        #region Construtor
        private readonly DbContextBase _context;
        public FormularioService(DbContextBase context)
        {
            _context = context;
        }
        #endregion

        public async Task<FormularioResponse> ObterFormulario(int Id)
        {
            try
            {
                var formulario = await _context.FORMULARIO
                                          .AsNoTracking()
                                          .Where(x => x.Id == Id)
                                          .Include(p => p.PerguntasNavigation)
                                            .ThenInclude(o => o.OpcoesPerguntaNavigation)
                                          .Select(x => new FormularioResponse()
                                          {
                                              Descricao = x.Descricao ?? string.Empty,
                                              DtCriacao = x.DtCriacao,
                                              Perguntas = x.PerguntasNavigation
                                                           .Select(p => new Pergunta()
                                                           {
                                                               Texto = p.TextoPergunta,
                                                               Ordem = p.Ordem,
                                                               Opcoes = p.OpcoesPerguntaNavigation
                                                                         .Select(o => new Opcao()
                                                                         {
                                                                             Texto = o.Texto,
                                                                             Ordem = o.Ordem
                                                                         }).OrderBy(x => x.Ordem)
                                                                           .ToList()
                                                           }).OrderBy(x => x.Ordem)
                                                             .ToList()
                                          }).FirstOrDefaultAsync();

                return formulario ?? new FormularioResponse();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<List<FormulariosResponse>> ObterFormularios(int NumeroPagina, int TamanhoPagina)
        {
            if (NumeroPagina <= 0 || TamanhoPagina <= 0)
                throw new ArgumentException("Numero da Página ou o Tamanho da Página devem ser maior que zero.");

            var query = await _context.FORMULARIO
                                .AsNoTracking()
                                .Where(x => x.IcAtivo)
                                .Include(u => u.UsuarioNavigation)
                                .Skip((NumeroPagina - 1) * TamanhoPagina)
                                .Take(TamanhoPagina)
                                .Select(x => new FormulariosResponse()
                                {
                                    Descricao = x.Descricao ?? string.Empty,
                                    IcAtivo = x.IcAtivo,
                                    DtCriacao = x.DtCriacao,
                                    Autor = x.UsuarioNavigation.Email
                                })
                                .OrderByDescending(x => x.DtCriacao)
                                .ToListAsync();

            return query;
        }

        public async Task CriarFormulario(FormularioRequest request)
        {
            try
            {
                var formulario = new FORMULARIO()
                {
                    IdUsuario = request.UsuarioId,
                    Descricao = request.Descricao,
                    DtCriacao = DateTime.UtcNow,
                    IcAtivo = true
                };

                await _context.FORMULARIO.AddAsync(formulario);
                await _context.SaveChangesAsync();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task AtualizarFormulario(EditFormularioRequest request)
        {
            try
            {
                var formulario = await _context.FORMULARIO
                                               .Where(x => x.Id == request.IdFormulario)
                                               .FirstOrDefaultAsync();

                if (formulario == null)
                    throw new ArgumentException("Usuário não encontrado");

                if(request.NovaDescricao != null)
                    formulario.Descricao = request.NovaDescricao;
                if(request.IcAtivo.HasValue)
                    formulario.IcAtivo = request.IcAtivo.Value;

                _context.Update(formulario);
                await _context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task DeleteForm()
        {

        }

        public async Task DisableForm()
        {

        }


    }
}
