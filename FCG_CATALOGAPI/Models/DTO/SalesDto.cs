namespace FCG_CATALOGAPI.Models.DTO
{
    public class SalesDto
    {
        public int IdSales { get; set; }
        public int IdClient { get; set; }
        public List<int> Games { get; set; }
    }
}
