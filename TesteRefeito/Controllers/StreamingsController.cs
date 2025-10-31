using Microsoft.AspNetCore.Mvc;
using TesteRefeito.DTOs;
using TesteRefeito.Services.Interfaces;

namespace TesteRefeito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StreamingsController : ControllerBase
    {
        private readonly IStreamingService _streamingService;
        public StreamingsController(IStreamingService streamingService)
        {
            _streamingService = streamingService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosStreamings()
        {
            try
            {
                var retorno = await _streamingService.ObterTodosStreamings();
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterStramingPorId(int id)
        {
            try
            {
                var retorno = await _streamingService.ObterStreamingPorId(id);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarStreaming([FromBody] StreamingDTO streamingDTO)
        {
            try
            {
                await _streamingService.AdcionarStreaming(streamingDTO);
                return Ok("Streaming cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarStreaming(int id, [FromBody] StreamingDTO streamingDTO)
        {
            try
            {
                await _streamingService.EditarStreaming(id, streamingDTO);
                return Ok("Streaming editado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirStreaming(int id)
        {
            try
            {
                await _streamingService.ExcluirStreaming(id);
                return Ok("Streaming excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
