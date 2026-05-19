using System.ComponentModel.DataAnnotations.Schema;

namespace MyBackend.Models
{
    [Table("StockTbl")]
    public class Stock {
        public int Id { get; set; }
        public int Quantity { get; set; }

        public int ProductId { get; set; }
    }
}