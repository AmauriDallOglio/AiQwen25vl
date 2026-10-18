using AiQwen25vl.Aplicacao.Util;

namespace AiQwen25vl.Aplicacao.Dto
{
    public class ResultadoQwenVisionDto<T> : ResultadoOperacao
    {
        public bool UsouOllamaReal { get; set; }
        public T? Dados { get; set; }
    }
}
