using Application.DTO.Response;
using Infrasctructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task ObterFormularios()
        {

        }

        public async Task CreateForm()
        {

        }





        public async Task UpdateForm()
        {

        }

        public async Task DeleteForm()
        {

        }

        public async Task DisableForm()
        {

        }


    }
}
