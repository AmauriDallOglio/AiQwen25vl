using AiQwen25vl.Aplicacao.Dto;
using AiQwen25vl.Aplicacao.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AiQwen25vl.Aplicacao.Rotas.Pesquisar
{
    public record PesquisarRequest(PesquisaUsuarioQwenDto Dados) : IRequest<ResultadoOperacao>;
}
