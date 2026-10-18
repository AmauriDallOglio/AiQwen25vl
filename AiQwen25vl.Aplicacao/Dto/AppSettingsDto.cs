namespace AiQwen25vl.Aplicacao.Dto
{
    public class AppSettingsDto
    {
        public LoggingDto Logging { get; set; } = new LoggingDto();
        public ConfiguracaoAiQwenVisionDto ConfiguracaoAiQwenVision { get; set; } = new ConfiguracaoAiQwenVisionDto();
        public RateLimitDto RateLimit { get; set; } = new RateLimitDto();
        public SegurancaDto Seguranca { get; set; } = new SegurancaDto();
    }

    public class LoggingDto
    {
        public LogLevelDto LogLevel { get; set; } = new LogLevelDto();
    }

    public class LogLevelDto
    {
        public string Default { get; set; } = string.Empty;
        [System.Text.Json.Serialization.JsonPropertyName("Microsoft.AspNetCore")]
        public string MicrosoftAspNetCore { get; set; } = string.Empty;
    }

    public class RateLimitDto
    {
        public bool Habilitado { get; set; } = true;
        public int RequisicoesPermitidas { get; set; } = 0;
        public int JanelaEmSegundos { get; set; } = 0;
        public int TamanhoFila { get; set; }
    }

    public class ConfiguracaoAiQwenVisionDto
    {
        public string UrlServidorOllama { get; set; } = string.Empty;
        public string ModeloVisionPadrao { get; set; } = string.Empty;
        public bool UsarOllamaReal { get; set; } = false;
        public long TamanhoMaximoImagemBytes { get; set; } = 0;
        public string TiposImagemPermitidos { get; set; } = string.Empty;
        public string PromptPadrao { get; set; } = string.Empty;
        public string Observacao { get; set; } = string.Empty;
    }

    public class SegurancaDto
    {
        public string ApiKey { get; set; } = string.Empty;
    }
}
