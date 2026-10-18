using System.ComponentModel.DataAnnotations;

namespace AiQwen25vl.Aplicacao.Dto
{
    public class UsuarioAcessoDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Informe o id do usuario, obrigatório.")]
        public Guid Id_Usuario { get; set; }
        public UsuarioDto Usuario { get; set; } = null!;

        [Required(ErrorMessage = "O campo serviço API é obrigatório.")]
        public string ServicoApi { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo rota acessada é obrigatório.")]
        public string RotaAcessada { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo método HTTP é obrigatório.")]
        public string MetodoHttp { get; set; } = string.Empty;

        public DateTime DataHoraAcesso { get; set; } = DateTime.Now;

        public string? EnderecoIp { get; set; }
        public string? UserAgent { get; set; }
        public string? IdentificadorRequisicao { get; set; }
        public int? CodigoStatus { get; set; }
        public bool Sucesso { get; set; } = true;
        public string? Mensagem { get; set; }

        public UsuarioAcessoDto() { }
        
        public UsuarioAcessoDto(
            Guid idUsuario,
            string servicoApi,
            string rotaAcessada,
            string metodoHttp)
        {
            Id_Usuario = idUsuario;
            ServicoApi = servicoApi;
            RotaAcessada = rotaAcessada;
            MetodoHttp = metodoHttp;
            DataHoraAcesso = DateTime.Now;
        }

        public void RegistrarResultado(int codigoStatus, bool sucesso, string? mensagem = null)
        {
            CodigoStatus = codigoStatus;
            Sucesso = sucesso;
            Mensagem = mensagem;
        }
    }
}
