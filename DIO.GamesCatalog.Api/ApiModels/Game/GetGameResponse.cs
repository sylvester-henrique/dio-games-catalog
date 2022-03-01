namespace DIO.GamesCatalog.Api.ApiModels.Game
{
    public class GetGameResponse
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int? Year { get; set; }
        public string Developer { get; set; }
        public string Publisher { get; set; }
        public string Genre { get; set; }
        public string Platform { get; set; }
        public double? Price { get; set; }
        public int? Inventory { get; set; }
    }
}
