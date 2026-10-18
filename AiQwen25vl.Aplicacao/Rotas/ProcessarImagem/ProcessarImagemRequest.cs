using AiQwen25vl.Aplicacao.Util;
using Microsoft.AspNetCore.Http;

namespace AiQwen25vl.Aplicacao.Rotas.ProcessarImagem
{
    public record ProcessarImagemRequest(Guid Id, string? Prompt, IFormFile Imagem) : IRequest<ResultadoOperacao>;

}
