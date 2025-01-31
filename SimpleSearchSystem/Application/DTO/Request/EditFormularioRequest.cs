namespace Application.DTO.Request
{
    public class EditFormularioRequest
    {
        public int IdFormulario { get; set; }
        public string? NovaDescricao { get; set; }
        public bool? IcAtivo { get; set; }
    }
}
