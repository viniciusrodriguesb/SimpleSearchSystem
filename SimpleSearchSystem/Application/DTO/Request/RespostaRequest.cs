namespace Application.DTO.Request
{
    public record RespostaRequest(DadosFormulario DadosFormulario, List<DadosResposta> DadosResposta);

    public record DadosFormulario(int IdFormulario, int IdUsuario);

    public record DadosResposta(int IdPergunta, int IdOpcao);

}
