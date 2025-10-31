using Microsoft.AspNetCore.Mvc;
using TesteRefeito.DTOs;
using TesteRefeito.Services.Interfaces;

namespace TesteRefeito.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmesService _filmesService;
        public FilmesController(IFilmesService filmesService)
        {
            _filmesService = filmesService;
        }

        [HttpGet]
        public async Task<IActionResult> ListarTodosFilmes()
        {
            try
            {
                var retorno = await _filmesService.ObterTodosFilmes();
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarFilmePorId(int id)
        {
            try
            {
                var retorno = await _filmesService.ObterFilmePorId(id);
                return Ok(retorno);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarFilme([FromBody] FilmeDTO filmeDTO)
        {
            try
            {
                await _filmesService.AdicionarFilme(filmeDTO);
                return Ok("Filme cadastrado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarFilme(int id, [FromBody] FilmeDTO filmeDTO)
        {
            try
            {
                await _filmesService.EditarFilme(id, filmeDTO);
                return Ok("Filme editado com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> ExcluirFilme(int id)
        {
            try
            {
                await _filmesService.ExcluirFilme(id);
                return Ok("Filme excluído com sucesso");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
