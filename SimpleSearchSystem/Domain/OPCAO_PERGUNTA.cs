namespace Domain
{
    public class OPCAO_PERGUNTA
    {
        public int Id { get; set; }
        public int PerguntaId { get; set; }
        public string Texto { get; set; } = string.Empty;
        public int Ordem { get; set; }

        #region Navigation
        public virtual PERGUNTA PerguntaNavigation { get; set; }
        public virtual ICollection<RESPOSTA_PERGUNTA> RespostasPerguntasNavigation { get; set; }
        #endregion
    }
}
