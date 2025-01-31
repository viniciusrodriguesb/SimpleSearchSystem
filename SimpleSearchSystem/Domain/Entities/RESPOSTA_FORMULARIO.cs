namespace Domain.Entities
{
    public class RESPOSTA_FORMULARIO
    {
        public int Id { get; set; }
        public int FormularioId { get; set; }
        public int UsuarioId { get; set; }
        public DateTime DtResposta { get; set; }

        #region Navigation
        public virtual USUARIO UsuarioNavigation { get; set; } = new USUARIO();
        public virtual FORMULARIO FormularioNavigation { get; set; } = new FORMULARIO();
        public virtual ICollection<RESPOSTA_PERGUNTA> RespostasPerguntas { get; set; } = new List<RESPOSTA_PERGUNTA>();
        #endregion

    }
}
