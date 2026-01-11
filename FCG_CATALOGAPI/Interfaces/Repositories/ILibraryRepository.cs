using FCG_CATALOGAPI.Models;

namespace FCG_CATALOGAPI.Interfaces.Repositories
{
    public interface ILibraryRepository
    {
        List<Library> GetByIdGame(int idGame);
        List<Library> GetByIdClient(int idClient);
        ServiceResult Add(List<Library> libraries);
    }
}
