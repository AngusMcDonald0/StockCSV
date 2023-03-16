using System.ComponentModel.DataAnnotations;
using CsvHelper.Configuration;
using CsvHelper.Configuration.Attributes;

namespace StockCSV.Models
{
    public class Trade
    {
        [Name("AsxCode")]
        public string? Code { get; set; }
        [Name("Order Type")]
        public string? TradeType { get; set; }
        [Name("Quantity")]
        public int Units { get; set; }
        [Name("Price")]
        public double Price { get; set; }
        [Name("Consideration")]
        public double Consideration { get; set; }
        [Name("Brokerage")]
        public double Brokerage { get; set; }
        [Name("GST")]
        public double GST { get; set; }
        [Name("Trade Date")]
        public DateTime PurchaseDate { get; set; }
    }
}
