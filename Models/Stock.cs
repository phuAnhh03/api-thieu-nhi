using System.ComponentModel.DataAnnotations.Schema;
namespace api.Models
{
    public class Stock
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        [Column(TypeName = "decimal(6,2)")]
        public decimal Purchase { get; set; }
        [Column(TypeName = "decimal(4,2)")]
        public decimal LastDiv { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal MarketCap { get; set; }
        public List<Comment> Comments { get; set; } = null!;
        public List<Ownership> Ownerships{ get; set; } = null!;
    }
}

