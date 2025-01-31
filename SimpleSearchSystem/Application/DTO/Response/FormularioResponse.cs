namespace Application.DTO.Response
{
    public class FormularioResponse
    {
        public string Descricao { get; set; } = string.Empty;
        public DateTime DtCriacao { get; set; }
        public List<Pergunta> Perguntas { get; set; }
    }

    public class Pergunta
    {
        public string Texto { get; set; } = string.Empty;
        public int Ordem { get; set; }
        public List<Opcao> Opcoes { get; set; }
    }

    public class Opcao
    {
        public string Texto { get; set; } = string.Empty;
        public int Ordem { get; set; }
    }

}
