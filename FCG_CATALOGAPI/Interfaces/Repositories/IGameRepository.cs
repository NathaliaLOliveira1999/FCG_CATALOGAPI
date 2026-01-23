using FCG_CATALOGAPI.Models;

namespace FCG_CATALOGAPI.Interfaces.Repositories
{
    public interface IGameRepository
    {
        IEnumerable<Game> GetAll();
        Game? GetById(int id);
        ServiceResult Add(Game game);
    }
}
