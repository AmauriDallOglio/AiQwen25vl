using AiQwen25vl.Aplicacao.Servico;
using AiQwen25vl.Aplicacao.Util;

namespace AiQwen25vl.Aplicacao.Rotas.Listar
{
    public class ListarHandler(UsuarioQwenVisionServico usuarios) : IContratoBaseHandler<ListarRequest, ResultadoOperacao>
    {
        public Task<ResultadoOperacao> Executar(ListarRequest request, CancellationToken cancelamento = default)
        {
            cancelamento.ThrowIfCancellationRequested();
            return Task.FromResult<ResultadoOperacao>((ResultadoOperacao.GerarSucesso(new ListarResponse { Dados = usuarios.Listar() }, "Usuarios listados.")));
        }
    }
}
