using System.ComponentModel.DataAnnotations;

namespace DIO.GamesCatalog.Api.ApiModels.Game
{
    public class PostGameRequest
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public int? Year { get; set; }

        [Required]
        public string Developer { get; set; }

        [Required]
        public string Publisher { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public string Platform { get; set; }

        public double? Price { get; set; }

        public int? Inventory { get; set; }
    }
}
