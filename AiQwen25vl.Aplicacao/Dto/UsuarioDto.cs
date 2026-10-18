using AiQwen25vl.Aplicacao.Util;
using System.ComponentModel.DataAnnotations;

namespace AiQwen25vl.Aplicacao.Dto
{
    public class UsuarioDto
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required(ErrorMessage = "Informe o id do do tenant, obrigatório.")]
        public Guid Id_Tenant { get; set; }
        public TenantDto Tenant { get; set; } = null!;

        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O e-mail informado é inválido.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "O campo senha é obrigatório.")]
        [MinLength(8, ErrorMessage = "A senha deve ter no mínimo 8 caracteres.")]
        public string Senha { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo token é obrigatório.")]
        public string? Token { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo código é obrigatório.")]
        public string? Codigo { get; set; } = string.Empty;
        [Required(ErrorMessage = "O campo aplicativo é obrigatório.")]
        public string? Aplicativo { get; set; } = string.Empty;

        public DateTime? UltimoAcesso { get; set; } = DateTime.Now;
        public DateTime DataCadastro { get; set; } = DateTime.Now;
        public DateTime? DataAlteracao { get; set; }
        public string? Refresh { get; set; }
        public ICollection<UsuarioAcessoDto> Acessos { get; set; } = new List<UsuarioAcessoDto>();


        public UsuarioDto() { }



        public void AtualizarToken(string token)
        {
            Token = token;
            AtualizarDataAlteracao();
        }

        public void AtualizarUltimoAcesso()
        {
            UltimoAcesso = DateTime.Now;
        }

        public void AtualizarSenha(string senha)
        {
            Senha = senha;
            AtualizarDataAlteracao();
        }

        public void AtualizarDataAlteracao()
        {
            DataAlteracao = DateTime.Now;
        }




        public void SetNovaSenha(string novaSenha)
        {
            // Validação da senha
            if (string.IsNullOrWhiteSpace(novaSenha))
                throw new ArgumentException("A senha não pode estar vazia.");

            if (novaSenha.Length < 8)
                throw new ArgumentException("A senha deve ter no mínimo 8 caracteres.");

            // Geração do hash da senha
            Senha = novaSenha.GerarHash();
        }


        public string GerarNovaSenha()
        {
            string novaSenha = Guid.NewGuid().ToString().Substring(0, 8);
            Senha = novaSenha.GerarHash();
            return novaSenha;
        }


    }
}
