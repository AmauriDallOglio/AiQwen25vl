using AiQwen25vl.Aplicacao.Servico;
using AiQwen25vl.Aplicacao.Util;

namespace AiQwen25vl.Aplicacao.Rotas.Inserir
{
    public class InserirHandler(UsuarioQwenVisionServico usuarios) : IContratoBaseHandler<InserirRequest, ResultadoOperacao>
    {
        public Task<ResultadoOperacao> Executar(InserirRequest request, CancellationToken cancelamento = default)
        {
            cancelamento.ThrowIfCancellationRequested();

            Task<ResultadoOperacao>? resultado = Task.FromResult<ResultadoOperacao>((ResultadoOperacao.GerarSucesso(new InserirResponse { Dados = usuarios.Inserir(request.Dados) }, "Usuario inserido.")));


            return resultado;
        }
    }
}
