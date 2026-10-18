using AiQwen25vl.Aplicacao.Dto;
using AiQwen25vl.Aplicacao.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiQwen25vl.Aplicacao.Rotas.Alterar
{
    public record AlterarRequest(Guid Id, UsuarioQwenAlterarDto Dados) : IRequest<ResultadoOperacao>;
}
