using FCG_CATALOGAPI.Interfaces.Repositories;
using FCG_CATALOGAPI.Models;

namespace FCG_CATALOGAPI.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly AppDbContext _context;

        public GameRepository(AppDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Game> GetAll() => _context.Games.ToList();

        public Game? GetById(int id) => _context.Games.Find(id);

        public ServiceResult Add(Game game)
        {
            try
            {
                game.IdGames = 0;
                _context.Games.Add(game);
                _context.SaveChanges();
                return ServiceResult.Ok(game);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.Message);
            }
        }
    }
}