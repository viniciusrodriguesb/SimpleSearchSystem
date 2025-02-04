namespace Domain
{
    public class LOGIN
    {
        public int Id { get; set; }
        public int IdUsuario { get; set; }
        public string Senha { get; set; } = string.Empty;

        #region Navigation
        public virtual USUARIO UsuarioNavigation { get; set; }
        #endregion

    }
}
