using System.ComponentModel.DataAnnotations;

namespace StockCSV.Models
{
    public class Holding
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Code { get; set; }
        public int Units { get; set; }
        public double AVGPrice { get; set; }
        public DateOnly PurchaseDate { get; set; }
    }
}
