using Microsoft.AspNetCore.Mvc;
using TesteRefeito.DTOs;
using TesteRefeito.Services.Interfaces;

namespace TesteRefeito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GenerosController : ControllerBase
    {
        private readonly IGeneroService _generoService;

        public GenerosController(IGeneroService generoService)
        {
            _generoService = generoService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosGeneros()
        {
            try
            {
                var retorno = await _generoService.ObterTodosGeneros();
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> BuscarGeneroPorId(int id)
        {
            try
            {
                var retorno = await _generoService.ObterGeneroPorId(id);
                return Ok(retorno);

            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CriaGenero([FromBody] GeneroDTO generoDTO)
        {
            try
            {
                await _generoService.AdicionarGenero(generoDTO);
                return Ok("Gênero criado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarGeneroExistente(int id, [FromBody] GeneroDTO generoDTO)
        {
            try
            {
                await _generoService.EditarGenero(id, generoDTO);
                return Ok("Gênero atualizado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarGenero(int id)
        {
            try
            {
                await _generoService.ExcluirGenero(id);
                return Ok("Gênero excluido com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
