using AiQwen25vl.Aplicacao.Dto;
using AiQwen25vl.Aplicacao.Util;

namespace AiQwen25vl.Aplicacao.Rotas.Inserir
{
    public record InserirRequest(UsuarioQwenCriarDto Dados) : IRequest<ResultadoOperacao>;
}       
