using System.ComponentModel.DataAnnotations.Schema;

namespace FCG_CATALOGAPI.Models.DTO
{
    public class LibrariesDto
    {
        public int IdClient { get; set; }
        public int IdGames { get; set; }
        public DateTime DtCreate { get; set; }
    }
}
