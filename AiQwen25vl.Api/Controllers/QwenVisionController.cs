using AiQwen25vl.Aplicacao.Rotas.Alterar;
using AiQwen25vl.Aplicacao.Rotas.Configuracao;
using AiQwen25vl.Aplicacao.Rotas.Excluir;
using AiQwen25vl.Aplicacao.Rotas.Inserir;
using AiQwen25vl.Aplicacao.Rotas.Listar;
using AiQwen25vl.Aplicacao.Rotas.Obter;
using AiQwen25vl.Aplicacao.Rotas.Pesquisar;
using AiQwen25vl.Aplicacao.Rotas.ProcessarImagem;
using AiQwen25vl.Aplicacao.Rotas.Status;
using Microsoft.AspNetCore.Mvc;

namespace AiQwen25vl.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class QwenVisionController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Listar([FromServices] ListarHandler rotaHandler, CancellationToken cancelamento)
        {
            var resultado = await rotaHandler.Executar(new ListarRequest(), cancelamento);
            return StatusCode(resultado.StatusCodigo ?? StatusCodes.Status200OK, resultado);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> Obter(Guid id, [FromServices] ObterHandler rotaHandler, CancellationToken cancelamento)
        {
            var resultado = await rotaHandler.Executar(new ObterRequest(id), cancelamento);
            return StatusCode(resultado.StatusCodigo ?? StatusCodes.Status200OK, resultado);
        }

        [HttpPost("inserir")]
        public async Task<IActionResult> Inserir([FromBody] InserirRequest request, [FromServices] InserirHandler rotaHandler, CancellationToken cancelamento)
        {
            var resultado = await rotaHandler.Executar(request, cancelamento);
            return StatusCode(resultado.StatusCodigo ?? StatusCodes.Status200OK, resultado);
        }


        [HttpPut("alterar/{id:guid}")]
        public async Task<IActionResult> Alterar(Guid id, [FromBody] AlterarRequest request, [FromServices] AlterarHandler rotaHandler, CancellationToken cancelamento)
        {
            var resultado = await rotaHandler.Executar(request, cancelamento);
            return StatusCode(resultado.StatusCodigo ?? StatusCodes.Status200OK, resultado);
        }

        [HttpDelete("excluir/{id:guid}")]
        public async Task<IActionResult> Excluir(Guid id, [FromServices] ExcluirHandler rotaHandler, CancellationToken cancelamento)
        {
            var resultado = await rotaHandler.Executar(new ExcluirRequest(id), cancelamento);
            return StatusCode(resultado.StatusCodigo ?? StatusCodes.Status200OK, resultado);
        }

        [HttpGet("pesquisar")]
        public async Task<IActionResult> Pesquisar([FromQuery] PesquisarRequest request, [FromServices] PesquisarHandler rotaHandler, CancellationToken cancelamento)
        {
            var resultado = await rotaHandler.Executar(request, cancelamento);
            return StatusCode(resultado.StatusCodigo ?? StatusCodes.Status200OK, resultado);
        }

        [HttpPost("processar-imagem")]
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> ProcessarImagem([FromForm] string? prompt, IFormFile imagem, [FromServices] ProcessarImagemHandler rotaHandler, CancellationToken cancelamento)
        {
            Guid id = Guid.Parse("11111111-1111-1111-1111-111111111111");
            var resultado = await rotaHandler.Executar(new ProcessarImagemRequest(id, prompt, imagem), cancelamento);
            return StatusCode(resultado.StatusCodigo ?? StatusCodes.Status200OK, resultado);
        }

        [HttpGet("status-integracao")]
        public async Task<IActionResult> Status([FromServices] StatusHandler rotaHandler, CancellationToken cancelamento)
        {
            var resultado = await rotaHandler.Executar(new StatusRequest(), cancelamento);
            return StatusCode(resultado.StatusCodigo ?? StatusCodes.Status200OK, resultado);
        }

        [HttpGet("configuracao-vision")]
        public async Task<IActionResult> Configuracao([FromServices] ConfiguracaoHandler rotaHandler, CancellationToken cancelamento)
        {
            var resultado = await rotaHandler.Executar(new ConfiguracaoRequest(), cancelamento);
            return StatusCode(resultado.StatusCodigo ?? StatusCodes.Status200OK, resultado);
        }

    }
}
