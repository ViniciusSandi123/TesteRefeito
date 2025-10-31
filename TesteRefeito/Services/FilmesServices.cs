using TesteRefeito.Data;
using TesteRefeito.DTOs;
using TesteRefeito.Models;
using TesteRefeito.Repositories.Interfaces;
using TesteRefeito.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using AutoMapper;

namespace TesteRefeito.Services
{
    public class FilmesServices : IFilmesService
    {
        private readonly IFilmeRepository _filmeRepository;
        private readonly IMapper _mapper;
        private readonly Context _context;

        public FilmesServices(IFilmeRepository filmeRepository, Context context, IMapper mapper)
        {
            _filmeRepository = filmeRepository;
            _context = context;
            _mapper = mapper;
        }

        public async Task AdicionarFilme(FilmeDTO filmeDTO)
        {
            var generos = await _context.Generos
                .Where(g => filmeDTO.Generos.Contains(g.Id))
                .ToListAsync();

            var streamings = await _context.Streamings
                .Where(s => filmeDTO.Streamings.Contains(s.Id))
                .ToListAsync();

            var filme = _mapper.Map<Filme>(filmeDTO);
            filme.Genero = generos;
            filme.Streaming = streamings;

            await _filmeRepository.AdicionarFilme(filme);
        }

        public async Task EditarFilme(int id, FilmeDTO filmeDTO)
        {
            var filme = await _filmeRepository.BuscarFilmePorId(id);
            _mapper.Map(filmeDTO, filme);
            await _filmeRepository.AlterarInformacaoFilme(filme);
        }

        public async Task ExcluirFilme(int id)
        {
            var filme = await _filmeRepository.BuscarFilmePorId(id);
            await _filmeRepository.RemoverFilme(id);
        }

        public async Task<FilmeDTO> ObterFilmePorId(int id)
        {
            var retorno = await _filmeRepository.BuscarFilmePorId(id);
            var filme = _mapper.Map<FilmeDTO>(retorno);
            return filme;
        }

        public async Task<List<FilmeDTO>> ObterTodosFilmes()
        {
            var retorno = await _filmeRepository.ListarFilmes();
            var filmes = _mapper.Map<List<FilmeDTO>>(retorno);
            return filmes;
        }
    }
}
