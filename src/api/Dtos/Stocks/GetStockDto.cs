using System.ComponentModel.DataAnnotations;
using api.Dtos.Comments;

namespace api.Dtos.Stocks
{
    public class GetStockDto
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(3, ErrorMessage = "maximum 4 characters")]
        public string Symbol { get; set; } = string.Empty;
        public string CompanyName { get; set; } = string.Empty;
        public string Industry { get; set; } = string.Empty;
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public decimal MarketCap { get; set; }
        public List<GetCommentDto> Comments { get; set; } = [];
    }
}