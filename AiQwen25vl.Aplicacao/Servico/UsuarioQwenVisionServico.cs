using AiQwen25vl.Aplicacao.Dto;

namespace AiQwen25vl.Aplicacao.Servico
{
    public class UsuarioQwenVisionServico
    {
        private readonly List<UsuarioDto> usuarios =
        [
            new UsuarioDto
        {
            Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Id_Tenant = Guid.Parse("11111111-1111-1111-1111-111111111111"),
            Nome = "Usuario Qwen Vision",
            Email = "qwen.vision@exemplo.com",
            Aplicativo = "Portal Qwen",
            Codigo = "QWEN-001",
            Senha = "senha-exemplo",
            Token = "ativo",
            UltimoAcesso = DateTime.Now.AddDays(-1),
            DataCadastro = DateTime.Now.AddDays(-10)
        }
        ];

        public IReadOnlyCollection<UsuarioQwenResposta> Listar() => usuarios.Select(MapearResposta).ToList();

        public UsuarioQwenResposta? Obter(Guid id)
        {
            var usuario = usuarios.FirstOrDefault(item => item.Id == id);
            return usuario is null ? null : MapearResposta(usuario);
        }

        public UsuarioDto? ObterEntidade(Guid id)
        {
            return usuarios.FirstOrDefault(item => item.Id == id);
        }

        public UsuarioQwenResposta Inserir(UsuarioQwenCriarDto requisicao)
        {
            var usuario = new UsuarioDto
            {
                Id = Guid.NewGuid(),
                Id_Tenant = requisicao.IdTenant,
                Nome = requisicao.Nome,
                Email = requisicao.Email,
                Aplicativo = requisicao.Aplicativo,
                Codigo = requisicao.Codigo,
                Senha = "senha-temporaria",
                Token = "ativo",
                UltimoAcesso = DateTime.Now,
                DataCadastro = DateTime.Now
            };

            usuarios.Add(usuario);
            return MapearResposta(usuario);
        }

        public UsuarioQwenResposta? Alterar(Guid id, UsuarioQwenAlterarDto requisicao)
        {
            var usuario = usuarios.FirstOrDefault(item => item.Id == id);
            if (usuario is null) return null;

            usuario.Id_Tenant = requisicao.IdTenant;
            usuario.Nome = requisicao.Nome;
            usuario.Email = requisicao.Email;
            usuario.Aplicativo = requisicao.Aplicativo;
            usuario.Codigo = requisicao.Codigo;
            usuario.Token = requisicao.Ativo ? "ativo" : string.Empty;
            usuario.DataAlteracao = DateTime.Now;

            return MapearResposta(usuario);
        }

        public bool Excluir(Guid id)
        {
            var usuario = usuarios.FirstOrDefault(item => item.Id == id);
            return usuario is not null && usuarios.Remove(usuario);
        }

        public IReadOnlyCollection<UsuarioQwenResposta> Pesquisar(PesquisaUsuarioQwenDto pesquisa)
        {
            var consulta = usuarios.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(pesquisa.Texto))
            {
                consulta = consulta.Where(usuario =>
                    usuario.Nome.Contains(pesquisa.Texto, StringComparison.OrdinalIgnoreCase) ||
                    usuario.Email.Contains(pesquisa.Texto, StringComparison.OrdinalIgnoreCase) ||
                    (usuario.Codigo?.Contains(pesquisa.Texto, StringComparison.OrdinalIgnoreCase) ?? false));
            }

            if (pesquisa.IdTenant.HasValue) consulta = consulta.Where(usuario => usuario.Id_Tenant == pesquisa.IdTenant.Value);
            if (!string.IsNullOrWhiteSpace(pesquisa.Aplicativo)) consulta = consulta.Where(usuario => usuario.Aplicativo?.Contains(pesquisa.Aplicativo, StringComparison.OrdinalIgnoreCase) == true);
            if (pesquisa.Ativo.HasValue) consulta = consulta.Where(usuario => pesquisa.Ativo.Value ? !string.IsNullOrWhiteSpace(usuario.Token) : string.IsNullOrWhiteSpace(usuario.Token));

            return consulta.Select(MapearResposta).ToList();
        }

        public static string MontarContextoUsuario(UsuarioDto usuario)
        {
            return $"Usuario {usuario.Nome}, email {usuario.Email}, aplicativo {usuario.Aplicativo}, codigo {usuario.Codigo}, ultimo acesso {usuario.UltimoAcesso:yyyy-MM-dd}.";
        }

        private static UsuarioQwenResposta MapearResposta(UsuarioDto usuario) => new()
        {
            Id = usuario.Id,
            IdTenant = usuario.Id_Tenant,
            Nome = usuario.Nome,
            Email = usuario.Email,
            Aplicativo = usuario.Aplicativo ?? string.Empty,
            Codigo = usuario.Codigo ?? string.Empty,
            Ativo = !string.IsNullOrWhiteSpace(usuario.Token),
            UltimoAcesso = usuario.UltimoAcesso,
            DataCadastro = usuario.DataCadastro
        };
    }

}