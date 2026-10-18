using AiQwen25vl.Aplicacao.Rotas.Alterar;
using AiQwen25vl.Aplicacao.Rotas.Excluir;
using AiQwen25vl.Aplicacao.Rotas.Inserir;
using AiQwen25vl.Aplicacao.Rotas.Listar;
using AiQwen25vl.Aplicacao.Rotas.Obter;
using AiQwen25vl.Aplicacao.Rotas.Pesquisar;
using AiQwen25vl.Aplicacao.Rotas.ProcessarImagem;
using AiQwen25vl.Aplicacao.Util;

namespace AiQwen25vl.Api.Configuracao
{
    public static class CqrsConfiguracao
    {
        public static IServiceCollection RegistrarCqrs(this IServiceCollection services)
        {
            //// Sessões Ollama
            services.RegistrarHandler<ListarRequest, ListarHandler>();
            services.RegistrarHandler<ObterRequest, ObterHandler>();
            services.RegistrarHandler<InserirRequest, InserirHandler>();
            services.RegistrarHandler<AlterarRequest, AlterarHandler>();
            services.RegistrarHandler<ExcluirRequest, ExcluirHandler>();
            services.RegistrarHandler<PesquisarRequest, PesquisarHandler>();
            services.RegistrarHandler<ProcessarImagemRequest, ProcessarImagemHandler>();


            return services;
        }

        private static IServiceCollection RegistrarHandler<TRequest, THandler>(this IServiceCollection services)
            where TRequest : IRequest<ResultadoOperacao>
            where THandler : class, IContratoBaseHandler<TRequest, ResultadoOperacao>
        {
            services.AddScoped<THandler>();
            services.AddScoped<IContratoBaseHandler<TRequest, ResultadoOperacao>, THandler>();

            return services;
        }
    }
}
