using AiQwen25vl.Aplicacao.Util;

namespace AiQwen25vl.Aplicacao.Rotas.Obter
{
    public record ObterRequest(Guid Id) : IRequest<ResultadoOperacao>;
}
