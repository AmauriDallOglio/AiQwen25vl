using AiQwen25vl.Aplicacao.Dto;
using AiQwen25vl.Aplicacao.Util;
using Microsoft.Extensions.Options;

namespace AiQwen25vl.Aplicacao.Rotas.Configuracao
{
    public class ConfiguracaoHandler(IOptions<ConfiguracaoAiQwenVisionDto> opcoes) : IContratoBaseHandler<ConfiguracaoRequest, ResultadoOperacao>
    {
        public Task<ResultadoOperacao> Executar(ConfiguracaoRequest request, CancellationToken cancelamento = default)
        {
            cancelamento.ThrowIfCancellationRequested();
            return Task.FromResult<ResultadoOperacao>((ResultadoOperacao.GerarSucesso(new ConfiguracaoResponse { Dados = opcoes.Value }, "Configuracao obtida.")));
        }
    }


}
