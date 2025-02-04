namespace Domain
{
    public class RESPOSTA_PERGUNTA
    {
        public int Id { get; set; }
        public int RespostaFormularioId { get; set; }
        public int PerguntaId { get; set; }
        public int OpcaoId { get; set; }

        #region Navigations
        public virtual RESPOSTA_FORMULARIO RespostaFormularioNavigation { get; set; } 
        public virtual PERGUNTA PerguntaNavigation { get; set; }
        public virtual OPCAO_PERGUNTA OpcaoPerguntaNavigation { get; set; } 
        #endregion

    }
}
