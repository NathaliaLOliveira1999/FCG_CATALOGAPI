using FCG_CATALOGAPI.Interfaces.Repositories;
using FCG_CATALOGAPI.Models;

namespace FCG_CATALOGAPI.Repositories
{
    public class LibraryRepository : ILibraryRepository
    {
        private readonly AppDbContext _context;

        public LibraryRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Library> GetByIdGame(int idGame) => _context.Libraries.Where(x => x.IdGames == idGame).ToList();

        public List<Library> GetByIdClient(int idClient) => _context.Libraries.Where(x => x.IdClient == idClient).ToList();

        public ServiceResult Add(List<Library> libraries)
        {
            try
            {
                _context.Libraries.AddRange(libraries);
                _context.SaveChanges();
                return ServiceResult.Ok(libraries);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail("Erro ao inserir itens na biblioteca: " + ex.Message);
            }
        }
    }
}
