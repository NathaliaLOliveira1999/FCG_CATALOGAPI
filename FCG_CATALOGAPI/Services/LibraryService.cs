using AutoMapper;
using FCG_CATALOGAPI.Interfaces.Repositories;
using FCG_CATALOGAPI.Interfaces.Services;
using FCG_CATALOGAPI.Models;
using FCG_CATALOGAPI.Models.DTO;

namespace FCG_CATALOGAPI.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly ILibraryRepository _libraryRepository;
        private readonly IMapper _mapper;

        public LibraryService(ILibraryRepository libraryRepository, IMapper mapper)
        {
            _libraryRepository = libraryRepository;
            _mapper = mapper;
        }

        public ServiceResult Add(LibraryDto library)
        {
            try
            {
                if (library.IdGames.Count <= 0)
                    return ServiceResult.Fail("Preencha os jogos a serem adicionados");
                var lista = new List<Models.Library>();

                foreach(var item in library.IdGames)
                {
                    lista.Add(new Models.Library() { IdClient = library.IdClient, IdGames = item, DtCreate = DateTime.Now });
                }
                _libraryRepository.Add(lista);
                return ServiceResult.Ok(library);
            }
            catch (Exception ex)
            {
                return ServiceResult.Fail(ex.Message);
            }
        }

        public List<LibrariesDto> GetByIdClient(int idCliente)
        {
            return _mapper.Map<List<LibrariesDto>>(_libraryRepository.GetByIdClient(idCliente));
        }

        public List<LibrariesDto> GetByIdGame(int idGame)
        {
            return _mapper.Map<List<LibrariesDto>>(_libraryRepository.GetByIdGame(idGame));
        }
    }
}
