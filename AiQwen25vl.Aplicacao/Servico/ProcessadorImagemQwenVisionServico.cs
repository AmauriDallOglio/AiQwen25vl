using AiQwen25vl.Aplicacao.Dto;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.RegularExpressions;

namespace AiQwen25vl.Aplicacao.Servico
{
    public class ProcessadorImagemQwenVisionServico
    {

        private readonly IOptions<AppSettingsDto> _appSettingsDto;
        private readonly IHttpClientFactory _httpClientFactory;

        ConfiguracaoAiQwenVisionDto configuracaoOllamaDto = new ConfiguracaoAiQwenVisionDto();

        public ProcessadorImagemQwenVisionServico(IOptions<AppSettingsDto> appSettingsDto, IWebHostEnvironment ambiente, IHttpClientFactory httpClientFactory)
        {
            _appSettingsDto = appSettingsDto;
            _httpClientFactory = httpClientFactory;

            configuracaoOllamaDto = _appSettingsDto.Value.ConfiguracaoAiQwenVision;
        }


        public async Task<ResultadoQwenVisionDto<object>> ProcessarImagem(UsuarioDto usuario, string? prompt, IFormFile imagem)
        {
            var validacao = ValidarImagem(imagem);
            if (!string.IsNullOrWhiteSpace(validacao)) 
                return CriarFalha<object>(validacao);
 
            var promptFinal = $"{(string.IsNullOrWhiteSpace(prompt) ? configuracaoOllamaDto.PromptPadrao : prompt)}\n\nContexto do usuario: {UsuarioQwenVisionServico.MontarContextoUsuario(usuario)}";
            var imagemBytes = await LerImagem(imagem);
            var imagemBase64 = Convert.ToBase64String(imagemBytes);
            string resposta;

            if (configuracaoOllamaDto.UsarOllamaReal)
            {
                try
                {
                    resposta = await ConsultarOllamaAsync( promptFinal, imagemBase64);
                }
                catch (OperationCanceledException)
                {
                    return CriarFalha<object>("O processamento da imagem foi cancelado ou excedeu o tempo limite.");
                }
                catch (HttpRequestException excecao)
                {
                    return CriarFalha<object>( $"Não foi possível conectar ao Ollama: {excecao.Message}");
                }
                catch (JsonException)
                {
                    return CriarFalha<object>( "O Ollama retornou uma resposta inválida.");
                }
                catch (Exception excecao)
                {
                    return CriarFalha<object>( $"Erro ao processar a imagem com Qwen2.5-VL: {excecao.Message}");
                }
            }
            else
            {
                resposta = $"Resposta simulada Qwen2.5-VL para {usuario.Nome}. " + $"Imagem '{imagem.FileName}' recebida com prompt: {promptFinal}";
                resposta = NormalizarResposta(resposta);
            }


            return CriarSucesso<object>(new
            {
                UsuarioId = usuario.Id,
                usuario.Nome,
                Prompt = promptFinal,
                Imagem = new { imagem.FileName, imagem.ContentType, TamanhoBytes = imagem.Length },
                Modelo = configuracaoOllamaDto.ModeloVisionPadrao,
                Resposta = resposta
            }, "Imagem processada com contexto do usuario.");
        }

        public ResultadoQwenVisionDto<object> ObterStatusIntegracao()
        {
   
            return CriarSucesso<object>(configuracaoOllamaDto, "Status da integracao Qwen2.5-VL obtido.");
        }

        private string? ValidarImagem(IFormFile imagem)
        {
 
            var tiposPermitidos = configuracaoOllamaDto.TiposImagemPermitidos.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if (imagem.Length == 0) 
                return "A imagem e obrigatoria.";
            
            if (imagem.Length > configuracaoOllamaDto.TamanhoMaximoImagemBytes) 
                return $"A imagem excede o limite de {configuracaoOllamaDto.TamanhoMaximoImagemBytes} bytes.";
            
            if (!tiposPermitidos.Contains(imagem.ContentType, StringComparer.OrdinalIgnoreCase)) 
                return $"Tipo de imagem nao permitido. Permitidos: {configuracaoOllamaDto.TiposImagemPermitidos}.";

            return null;
        }

        private static async Task<byte[]> LerImagem(IFormFile imagem)
        {
            using var memoria = new MemoryStream();
            await imagem.CopyToAsync(memoria);
            return memoria.ToArray();
        }

        private static string NormalizarResposta(string resposta)
        {
            return string.IsNullOrWhiteSpace(resposta) ? string.Empty : Regex.Replace(resposta, @"\s+", " ").Trim();
        }

        private ResultadoQwenVisionDto<T> CriarSucesso<T>(T dados, string mensagem)
        {
            return new() { Sucesso = true, Mensagem = mensagem, UsouOllamaReal = configuracaoOllamaDto.UsarOllamaReal, Dados = dados };
        }

        private ResultadoQwenVisionDto<T> CriarFalha<T>(string mensagem)
        {
            return new() { Sucesso = false, Mensagem = mensagem, UsouOllamaReal = configuracaoOllamaDto.UsarOllamaReal };
        }



        private async Task<string> ConsultarOllamaAsync( string prompt, string imagemBase64, CancellationToken cancellationToken = default)
        {
            var cliente = _httpClientFactory.CreateClient("Ollama");
            var url = $"{configuracaoOllamaDto.UrlServidorOllama.TrimEnd('/')}/api/chat";
            var requisicao = new
            {
                model = configuracaoOllamaDto.ModeloVisionPadrao,
                stream = false,
                messages = new[]
                {
                    new
                    {
                        role = "user",
                        content = prompt,
                        images = new[] { imagemBase64 }
                    }
                }
            };

            using HttpResponseMessage respostaHttp = await cliente.PostAsJsonAsync(  url, requisicao, cancellationToken);

            respostaHttp.EnsureSuccessStatusCode();

            await using Stream stream = await respostaHttp.Content.ReadAsStreamAsync(cancellationToken);

            using JsonDocument documento = await JsonDocument.ParseAsync( stream,   cancellationToken: cancellationToken);

            string? resultado =  documento.RootElement.GetProperty("message").GetProperty("content").GetString() ?? string.Empty;
            return resultado;
        }



    }
}
