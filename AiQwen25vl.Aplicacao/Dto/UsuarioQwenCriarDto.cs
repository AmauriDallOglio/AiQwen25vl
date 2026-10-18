namespace AiQwen25vl.Aplicacao.Dto
{
    public class UsuarioQwenCriarDto
    {
        public Guid IdTenant { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Aplicativo { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
    }

}
