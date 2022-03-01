namespace DIO.GamesCatalog.Api.Entities
{
    public class Game
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public double? Price { get; set; }
        public double? Inventory { get; set; }
    }
}
