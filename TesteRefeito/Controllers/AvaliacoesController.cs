using Microsoft.AspNetCore.Mvc;
using TesteRefeito.DTOs;
using TesteRefeito.Services.Interfaces;

namespace TesteRefeito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AvaliacoesController : ControllerBase
    {
        private readonly IAvaliacaoService _avaliacaoService;
        public AvaliacoesController(IAvaliacaoService avaliacaoService)
        {
            _avaliacaoService = avaliacaoService;
        }
        [HttpGet]
        public async Task<IActionResult> ConsultarTodasAvalicoes()
        {
            try
            {
                var retorno = await _avaliacaoService.ObterTodasAvaliacoes();
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ConsultarAvaliacaoPorId(int id)
        {
            try
            {
                var retorno = await _avaliacaoService.ObterAvaliacaoPorId(id);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriarAvaliacao([FromBody] AvaliacaoDTO avaliacaoDTO)
        {
            try
            {
                await _avaliacaoService.AdicionarAvaliacao(avaliacaoDTO);
                return Ok("Avaliação criada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarAvaliacao(int id, [FromBody] AvaliacaoDTO avaliacaoDTO)
        {
            try
            {
                await _avaliacaoService.EditarAvaliacao(id, avaliacaoDTO);
                return Ok("Avaliação editada com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _avaliacaoService.ExcluirAvaliacao(id);
                return Ok("Avaliação excluída com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
