namespace Domain.Entities
{
    public class FORMULARIO
    {
        public int Id { get; set; }
        public int? IdUsuario { get; set; }
        public string? Descricao { get; set; }
        public DateTime DtCriacao { get; set; }
        public bool IcAtivo { get; set; }

        #region Navigation
        public virtual USUARIO UsuarioNavigation { get; set; } = new USUARIO();
        public virtual ICollection<PERGUNTA> PerguntasNavigation { get; set; } = new List<PERGUNTA>();
        public virtual ICollection<RESPOSTA_FORMULARIO> RespostasFormularioNavigation { get; set; } = new List<RESPOSTA_FORMULARIO>();
        #endregion

    }
}
