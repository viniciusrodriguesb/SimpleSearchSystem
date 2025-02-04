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
        public virtual LOGIN LoginNavigation { get; set; } 
        public virtual ICollection<FORMULARIO> FormulariosNavigation { get; set; } 
        public virtual ICollection<RESPOSTA_FORMULARIO> RespostasFormularioNavigation { get; set; } 
        #endregion

    }
}
