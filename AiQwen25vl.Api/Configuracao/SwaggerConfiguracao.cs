namespace AiQwen25vl.Api.Configuracao
{
    public static class SwaggerConfiguracao
    {
        public static void ConfiguracaoSwagger(this IServiceCollection services)
        {
            services.RegistrarCqrs();
            services.AddControllers();
            services.AddEndpointsApiExplorer();

            // Registra o HttpClientFactory para chamadas ao Ollama
            services.AddHttpClient("Ollama", cliente =>
            {
                cliente.Timeout = TimeSpan.FromMinutes(5);
            });

            ApiKey(services);

        }

        private static void ApiKey(this IServiceCollection services)
        {
            services.AddSwaggerGen(options =>
            {
                options.AddSecurityDefinition("ApiKey", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Name = "X-Api-Key",
                    In = Microsoft.OpenApi.Models.ParameterLocation.Header,
                    Type = Microsoft.OpenApi.Models.SecuritySchemeType.ApiKey,
                    Description = "Informe a API Key do serviço"
                });

                options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
                {
                    {
                        new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                        {
                            Reference = new Microsoft.OpenApi.Models.OpenApiReference
                            {
                                Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                                Id = "ApiKey"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });
        }

    }
}

