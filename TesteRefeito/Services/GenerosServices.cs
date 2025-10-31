using AutoMapper;
using TesteRefeito.DTOs;
using TesteRefeito.Models;
using TesteRefeito.Repositories.Interfaces;
using TesteRefeito.Services.Interfaces;

namespace TesteRefeito.Services
{
    public class GenerosServices : IGeneroService
    {
        private readonly IGeneroRepository _generoRepository;
        private readonly IMapper _mapper;
        public GenerosServices(IGeneroRepository generoRepository, IMapper mapper)
        {
            _generoRepository = generoRepository;
            _mapper = mapper;
        }

        public async Task AdicionarGenero(GeneroDTO generoDTO)
        {
            var genero = _mapper.Map<Genero>(generoDTO);
            await _generoRepository.AdicionarGenero(genero);
        }

        public async Task<GeneroDTO> ObterGeneroPorId(int id)
        {
            var retorno = await _generoRepository.BuscarGeneroPorId(id);
            var genero = _mapper.Map<GeneroDTO>(retorno);
            return genero;
        }

        public async Task<List<GeneroDTO>> ObterTodosGeneros()
        {
            var retorno = await _generoRepository.ListarGeneros();
            var generos = _mapper.Map<List<GeneroDTO>>(retorno);
            return generos;
        }

        public async Task EditarGenero(int id, GeneroDTO generoDTO)
        {
            var retorno = await _generoRepository.BuscarGeneroPorId(id);
            var genero = _mapper.Map(generoDTO, retorno);
            await _generoRepository.AlterarInformacaoGenero(genero);
        }

        public async Task ExcluirGenero(int id)
        {
            var genero = await _generoRepository.BuscarGeneroPorId(id);
            await _generoRepository.RemoverGenero(id);
        }
    }
}
