namespace Application.DTO.Response
{
    public class PaginacaoResponse<T> where T : class
    {
        public IEnumerable<T>? Itens { get; set; }
        public int Total { get; set; }
    }
}
