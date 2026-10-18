using AiQwen25vl.Aplicacao.Servico;
using AiQwen25vl.Aplicacao.Util;

namespace AiQwen25vl.Aplicacao.Rotas.Excluir
{
    public class ExcluirHandler(UsuarioQwenVisionServico usuarios) : IContratoBaseHandler<ExcluirRequest, ResultadoOperacao>
    {
        public Task<ResultadoOperacao> Executar(ExcluirRequest request, CancellationToken cancelamento = default)
        {
            cancelamento.ThrowIfCancellationRequested();

            bool excluido = usuarios.Excluir(request.Id);

            if (!excluido)
            {
                return Task.FromResult(ResultadoOperacao.GerarErro("Usuário não encontrado.", 400));
            }

            var resposta = new ExcluirResponse
            {
                Dados = true
            };

            return Task.FromResult(ResultadoOperacao.GerarSucesso(resposta, "Usuário excluido."));
        }
    }
}
