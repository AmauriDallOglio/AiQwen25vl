using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiQwen25vl.Aplicacao.Dto
{
    public class PesquisaUsuarioQwenDto
    {
        public string? Texto { get; set; }
        public Guid? IdTenant { get; set; }
        public string? Aplicativo { get; set; }
        public bool? Ativo { get; set; }
    }
}
