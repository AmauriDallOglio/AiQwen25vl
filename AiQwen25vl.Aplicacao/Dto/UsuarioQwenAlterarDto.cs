using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiQwen25vl.Aplicacao.Dto
{
    public class UsuarioQwenAlterarDto
    {
        public Guid IdTenant { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Aplicativo { get; set; } = string.Empty;
        public string Codigo { get; set; } = string.Empty;
        public bool Ativo { get; set; } = true;
    }
}
