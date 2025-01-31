namespace Domain
{
    public class PERGUNTA
    {
        public int Id { get; set; }
        public int FormularioId { get; set; }
        public string TextoPergunta { get; set; } = string.Empty;
        public int Ordem { get; set; }

        #region Navigation
        public virtual FORMULARIO FormularioNavigation { get; set; } = new FORMULARIO();
        public virtual ICollection<OPCAO_PERGUNTA> OpcoesPerguntaNavigation { get; set; } = new List<OPCAO_PERGUNTA>();
        #endregion

    }
}
