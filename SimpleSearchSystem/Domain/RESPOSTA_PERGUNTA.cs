namespace Domain
{
    public class RESPOSTA_PERGUNTA
    {
        public int Id { get; set; }
        public int RespostaFormularioId { get; set; }
        public int PerguntaId { get; set; }
        public int OpcaoId { get; set; }

        #region Navigations
        public virtual RESPOSTA_FORMULARIO RespostaFormularioNavigation { get; set; } = new RESPOSTA_FORMULARIO();
        public virtual PERGUNTA PerguntaNavigation { get; set; } = new PERGUNTA();
        public virtual OPCAO_PERGUNTA OpcaoPerguntaNavigation { get; set; } = new OPCAO_PERGUNTA();
        #endregion

    }
}
