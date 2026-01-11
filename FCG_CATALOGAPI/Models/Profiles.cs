using AutoMapper;
using FCG_CATALOGAPI.Models.DTO;

namespace FCG_CATALOGAPI.Models
{
    public class Profiles : Profile
    {
        public Profiles()
        {
            // Mapeia DTO -> Entidade
            CreateMap<LibrariesDto, Library>()
                    .ForMember(dest => dest.IdGames, opt => opt.Ignore());


            // (opcional) Entidade -> DTO
            CreateMap<Game, GameDto>();
            CreateMap<Library, LibrariesDto>();
        }
    }
}
