
using Application.DTO.Response;
using Microsoft.EntityFrameworkCore;

namespace Application.Services
{
    public class PaginacaoService<T> where T : class
    {
        public async Task<PaginacaoResponse<T>> PaginarDadosAsync(IQueryable<T> query, int NumeroPagina, int TamanhoPagina)
        {

            if (NumeroPagina <= 0 || TamanhoPagina <= 0)
                throw new ArgumentException("Numero da Página ou o Tamanho da Página devem ser maior que zero.");

            try
            {
                var total = await query.CountAsync();

                var result = await query.Skip((NumeroPagina - 1) * TamanhoPagina)
                                        .Take(TamanhoPagina)
                                        .ToListAsync();

                return new PaginacaoResponse<T>()
                {
                    Itens = result ?? Enumerable.Empty<T>(),
                    Total = total
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
