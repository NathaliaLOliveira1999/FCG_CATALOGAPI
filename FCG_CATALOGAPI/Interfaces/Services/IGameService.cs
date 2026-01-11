using FCG_CATALOGAPI.Models;
using FCG_CATALOGAPI.Models.DTO;

namespace FCG_CATALOGAPI.Interfaces.Services
{
    public interface IGameService
    {
        List<GameDto> GetAll();
        GameDto? GetById(int id);
        ServiceResult Add(GameDto game);
    }
}
