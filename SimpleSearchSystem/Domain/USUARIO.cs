namespace Domain
{
    public class USUARIO
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public int Idade { get; set; }
        public char? Genero { get; set; }
        public DateTime DtCriacao { get; set; }

        #region Navigation
        public virtual LOGIN LoginNavigation { get; set; } = new LOGIN();
        public virtual ICollection<FORMULARIO> FormulariosNavigation { get; set; } = new List<FORMULARIO>();
        public virtual ICollection<RESPOSTA_FORMULARIO> RespostasFormularioNavigation { get; set; } = new List<RESPOSTA_FORMULARIO>();
        #endregion

    }
}
