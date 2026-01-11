using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCG_CATALOGAPI.Models
{

    [Table("GAMES")]
    public class Game
    {
        [Key]
        [Column("IDGAMES")]
        public int IdGames { get; set; }
        [Column("TITLE")]
        public string Title { get; set; }
        [Column("DETAILS")]
        public string Details { get; set; }
        [Column("PLATFORMS")]
        public string Plataform { get; set; }
        [Column("CATEGORY")]
        public string Category { get; set; }
        [Column("DEVELOPER")]
        public string Developer { get; set; }
        [Column("DTRELEASE")]
        public DateTime DtRelease { get; set; }
        [Column("PRICE")]
        public decimal PRICE { get; set; }
        [Column("IMAGES")]
        public string IMAGES { get; set; }
        [Column("DTCREATE")]
        public DateTime DTCREATE { get; set; }
        [Column("ACTIVE")]
        public bool ACTIVE { get; set; }
    }
}
