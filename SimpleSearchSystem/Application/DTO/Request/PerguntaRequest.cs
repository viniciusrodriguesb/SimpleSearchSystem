namespace Application.DTO.Request
{

    public record PerguntaRequest(int FormularioId, string Pergunta, int Ordem, List<OpcaoRequest> OpcoesRespostas);

    public record OpcaoRequest(string TextoOpcao, int Ordem);

}
