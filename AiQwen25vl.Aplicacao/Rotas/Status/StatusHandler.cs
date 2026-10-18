using AiQwen25vl.Aplicacao.Servico;
using AiQwen25vl.Aplicacao.Util;

namespace AiQwen25vl.Aplicacao.Rotas.Status
{
    public class StatusHandler(ProcessadorImagemQwenVisionServico processador) : IContratoBaseHandler<StatusRequest, ResultadoOperacao>
    {
        public Task<ResultadoOperacao> Executar(StatusRequest request, CancellationToken cancelamento = default)
        {
            cancelamento.ThrowIfCancellationRequested();
            var resultado = processador.ObterStatusIntegracao();
            return Task.FromResult<ResultadoOperacao>((resultado.Sucesso ? ResultadoOperacao.GerarSucesso(new StatusResponse { Dados = resultado.Dados }, resultado.Mensagem) : ResultadoOperacao.GerarErro(string.IsNullOrWhiteSpace(resultado.Mensagem) ? string.Join("; ", resultado.Erros) : resultado.Mensagem, 400)));
        }
    }
}
