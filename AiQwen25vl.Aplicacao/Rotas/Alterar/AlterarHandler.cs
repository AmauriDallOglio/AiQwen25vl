using AiQwen25vl.Aplicacao.Servico;
using AiQwen25vl.Aplicacao.Util;

namespace AiQwen25vl.Aplicacao.Rotas.Alterar
{
    public class AlterarHandler(UsuarioQwenVisionServico usuarios) : IContratoBaseHandler<AlterarRequest, ResultadoOperacao>
    {
        public Task<ResultadoOperacao> Executar(AlterarRequest request, CancellationToken cancelamento = default)
        {
            if (request.Id == Guid.Empty)
            {
                return Task.FromResult(
                    ResultadoOperacao.GerarErro("Usuário não encontrado.", 400));
            }

            var dado = usuarios.Alterar(request.Id, request.Dados);

            if (dado == null)
            {
                return Task.FromResult(
                    ResultadoOperacao.GerarErro("Usuário não encontrado.", 400));
            }

            var resposta = new AlterarResponse
            {
                Dados = dado
            };

            return Task.FromResult(
                ResultadoOperacao.GerarSucesso(resposta, "Usuário alterado."));
        }
    }

}
