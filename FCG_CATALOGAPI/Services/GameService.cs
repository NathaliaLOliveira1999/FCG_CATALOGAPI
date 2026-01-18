using AutoMapper;
using FCG_CATALOGAPI.Interfaces.Repositories;
using FCG_CATALOGAPI.Interfaces.Services;
using FCG_CATALOGAPI.Models;
using FCG_CATALOGAPI.Models.DTO;

namespace FCG_CATALOGAPI.Services
{
    public class GameService : IGameService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IMapper _mapper;

        public GameService(IGameRepository gameRepository, IMapper mapper)
        {
            _mapper = mapper;
            _gameRepository = gameRepository;
        }

        public List<GameDto> GetAll()
        {
            return _mapper.Map<List<GameDto>>(_gameRepository.GetAll());
        }

        public GameDto? GetById(int id)
        {
            return _mapper.Map<GameDto>(_gameRepository.GetById(id));
        }

        public ServiceResult Add(GameDto game)
        {
            try
            {
                _gameRepository.Add(_mapper.Map<Game>(game));
                return ServiceResult.Ok(game);
            }
            catch (Exception ex) {
                return ServiceResult.Fail(ex.Message);
            }
        }

        public decimal GetValues(List<int> games)
        {
            var retorno = new decimal();
            foreach (var item in games)
            {
                var game = _gameRepository.GetById(item);
                if (game != null)
                    retorno += game.PRICE;
            }
            return retorno;
        }
    }
}