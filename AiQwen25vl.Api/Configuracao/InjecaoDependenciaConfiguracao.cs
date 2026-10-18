using AiQwen25vl.Aplicacao.Rotas.Alterar;
using AiQwen25vl.Aplicacao.Rotas.Configuracao;
using AiQwen25vl.Aplicacao.Rotas.Excluir;
using AiQwen25vl.Aplicacao.Rotas.Inserir;
using AiQwen25vl.Aplicacao.Rotas.Listar;
using AiQwen25vl.Aplicacao.Rotas.Obter;
using AiQwen25vl.Aplicacao.Rotas.Pesquisar;
using AiQwen25vl.Aplicacao.Rotas.ProcessarImagem;
using AiQwen25vl.Aplicacao.Rotas.Status;
using AiQwen25vl.Aplicacao.Servico;
using Microsoft.AspNetCore.Mvc;

namespace AiQwen25vl.Api.Configuracao
{
    public class InjecaoDependenciaConfiguracao
    {
        public static void RegistrarServicos(WebApplicationBuilder builder)
        {


            builder.Services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });


            builder.Services.AddScoped<ListarHandler>();
            builder.Services.AddScoped<ObterHandler>();
            builder.Services.AddScoped<InserirHandler>();
            builder.Services.AddScoped<AlterarHandler>();
            builder.Services.AddScoped<ExcluirHandler>();
            builder.Services.AddScoped<PesquisarHandler>();
            builder.Services.AddScoped<ProcessarImagemHandler>();
            builder.Services.AddScoped<StatusHandler>();
            builder.Services.AddScoped<ConfiguracaoHandler>();


            builder.Services.AddScoped<ProcessadorImagemQwenVisionServico>();
            builder.Services.AddScoped<UsuarioQwenVisionServico>();
        }
    }
}