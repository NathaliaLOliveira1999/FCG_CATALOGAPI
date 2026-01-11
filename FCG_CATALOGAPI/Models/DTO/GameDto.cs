namespace FCG_CATALOGAPI.Models.DTO
{
    public class GameDto
    {
        public int IdGames { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
        public string Plataform { get; set; }
        public string Category { get; set; }
        public string Developer { get; set; }
        public DateTime DtRelease { get; set; }
        public decimal PRICE { get; set; }
        public string IMAGES { get; set; }
        public DateTime DTCREATE { get; set; }
        public bool ACTIVE { get; set; }
    }
}
