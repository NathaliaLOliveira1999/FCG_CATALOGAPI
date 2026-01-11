using FCG_CATALOGAPI.Models;
using FCG_CATALOGAPI.Models.DTO;

namespace FCG_CATALOGAPI.Interfaces.Services
{
    public interface ILibraryService
    {
        ServiceResult Add(LibraryDto library);
        List<LibrariesDto> GetByIdClient(int idCliente);
        List<LibrariesDto> GetByIdGame(int idGame);
    }
}
