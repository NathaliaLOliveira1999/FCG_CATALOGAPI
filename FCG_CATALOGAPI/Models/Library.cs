using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCG_CATALOGAPI.Models
{
    [Table("CLIENT_LIBRARY")]
    public class Library
    {
        [Key]
        [Column("IDCLIENT")]
        public int IdClient { get; set; }
        [Column("IDGAMES")]
        public int IdGames { get; set; }
        [Column("DTCREATE")]
        public DateTime DtCreate { get; set; }
    }
}
