using AiQwen25vl.Aplicacao.Servico;
using AiQwen25vl.Aplicacao.Util;

namespace AiQwen25vl.Aplicacao.Rotas.Pesquisar
{
    public class PesquisarHandler(UsuarioQwenVisionServico usuarios) : IContratoBaseHandler<PesquisarRequest, ResultadoOperacao>
    {
        public Task<ResultadoOperacao> Executar(PesquisarRequest request, CancellationToken cancelamento = default)
        {
            cancelamento.ThrowIfCancellationRequested();
            return Task.FromResult<ResultadoOperacao>((ResultadoOperacao.GerarSucesso(new PesquisarResponse { Dados = usuarios.Pesquisar(request.Dados) }, "Pesquisa realizada.")));
        }
    }

}
