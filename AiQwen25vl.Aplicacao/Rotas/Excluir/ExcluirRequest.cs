using AiQwen25vl.Aplicacao.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiQwen25vl.Aplicacao.Rotas.Excluir
{
    public record ExcluirRequest(Guid Id) : IRequest<ResultadoOperacao>;
}
