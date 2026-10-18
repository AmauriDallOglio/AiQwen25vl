using AiQwen25vl.Aplicacao.Servico;
using AiQwen25vl.Aplicacao.Util;

namespace AiQwen25vl.Aplicacao.Rotas.Obter
{
    public class ObterHandler(UsuarioQwenVisionServico usuarios) : IContratoBaseHandler<ObterRequest, ResultadoOperacao>
    {
        public Task<ResultadoOperacao> Executar(ObterRequest request, CancellationToken cancelamento = default)
        {
            cancelamento.ThrowIfCancellationRequested();
            return Task.FromResult<ResultadoOperacao>(usuarios.Obter(request.Id) is { } dado ? (ResultadoOperacao.GerarSucesso(new ObterResponse { Dados = dado }, "Usuario obtido.")) : (ResultadoOperacao.GerarErro("Usuario nao encontrado.", 404)));
        }
    }
}
