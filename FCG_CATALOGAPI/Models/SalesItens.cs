using FCG_CATALOGAPI.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FCG_CATALOGAPI.Model
{
    [Table("SALESITEM")]
    public class SalesItens
    {
        [Key]
        [Column("IDSALESITEM")]
        public int IdSalesItem { get; set; }

        [Column("IDSALES")]
        public int IdSales { get; set; }

        [Column("IDGAMES")]
        public int IdGames { get; set; }
    }
}
