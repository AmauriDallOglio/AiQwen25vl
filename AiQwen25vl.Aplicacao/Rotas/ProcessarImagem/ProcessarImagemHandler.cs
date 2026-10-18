using AiQwen25vl.Aplicacao.Servico;
using AiQwen25vl.Aplicacao.Util;

namespace AiQwen25vl.Aplicacao.Rotas.ProcessarImagem
{
    public class ProcessarImagemHandler(UsuarioQwenVisionServico usuarios, ProcessadorImagemQwenVisionServico processador) : IContratoBaseHandler<ProcessarImagemRequest, ResultadoOperacao>
    {
        public async Task<ResultadoOperacao> Executar(ProcessarImagemRequest request, CancellationToken cancelamento = default)
        {
            cancelamento.ThrowIfCancellationRequested();

 
            var usuario = usuarios.ObterEntidade(request.Id);
            if (usuario is null) 
                return (ResultadoOperacao.GerarErro("Usuario nao encontrado.", 400));

            var resultado = await processador.ProcessarImagem(usuario, request.Prompt, request.Imagem);
            if (resultado.Sucesso)
            {
                return ResultadoOperacao.GerarSucesso(new ProcessarImagemResponse { Dados = resultado.Dados }, resultado.Mensagem);
            }
            else
            {
                return ResultadoOperacao.GerarErro(string.IsNullOrWhiteSpace(resultado.Mensagem) ? string.Join("; ", resultado.Erros) : resultado.Mensagem, 400);
            }
        }
    }
}