namespace Application.DTO.Request
{
    public record EditFormularioRequest(int IdFormulario, string? NovaDescricao, bool? IcAtivo);
}
