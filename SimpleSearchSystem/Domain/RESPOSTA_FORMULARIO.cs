namespace Domain
{
    public class RESPOSTA_FORMULARIO
    {
        public int Id { get; set; }
        public int FormularioId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DtResposta { get; set; }

        #region Navigation
        public virtual USUARIO UsuarioNavigation { get; set; }
        public virtual FORMULARIO FormularioNavigation { get; set; }
        public virtual ICollection<RESPOSTA_PERGUNTA> RespostasPerguntasNavigation { get; set; } 
        #endregion

    }
}
