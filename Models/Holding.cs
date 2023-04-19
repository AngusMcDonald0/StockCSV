using System.ComponentModel.DataAnnotations;


namespace StockCSV.Models
{
    public class Holding
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Code { get; set; }
        public int Units { get; set; }
        public double AVGPrice { get; set; }
        public DateTime PurchaseDate { get; set; }

        public Holding() { }

        public Holding(string? code, int units, double aVGPrice, DateTime purchaseDate)
        {
            Id = Int32.Parse(Guid.NewGuid().ToString());
            Code = code;
            Units = units;
            AVGPrice = aVGPrice;
            PurchaseDate = purchaseDate;
        }
    }
}
