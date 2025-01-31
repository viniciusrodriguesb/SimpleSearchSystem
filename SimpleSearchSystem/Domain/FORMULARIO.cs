namespace Domain
{
    public class FORMULARIO
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public string? Descricao { get; set; }
        public DateTime DtCriacao { get; set; }
        public bool IcAtivo { get; set; }

        #region Navigation
        public virtual USUARIO UsuarioNavigation { get; set; }
        public virtual ICollection<PERGUNTA> PerguntasNavigation { get; set; }
        public virtual ICollection<RESPOSTA_FORMULARIO> RespostasFormularioNavigation { get; set; }
        #endregion

    }
}
