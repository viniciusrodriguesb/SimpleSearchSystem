namespace Application.DTO.Request
{
    public record EditPerguntaRequest(int IdPergunta, string? NovoTexto, int? NovaOrdem);
}
