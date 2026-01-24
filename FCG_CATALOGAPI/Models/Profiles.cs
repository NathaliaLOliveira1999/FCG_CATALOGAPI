using AutoMapper;
using FCG_CATALOGAPI.Models.DTO;

namespace FCG_CATALOGAPI.Models
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            // Mapeia DTO -> Entidade
            CreateMap<LibrariesDto, Library>();
            CreateMap<GameDto, Game>();
            CreateMap<SalesDto, Sales>();


            // (opcional) Entidade -> DTO
            CreateMap<Game, GameDto>();
            CreateMap<Library, LibrariesDto>();
            CreateMap<Sales, SalesDto>();
        }
    }
}
