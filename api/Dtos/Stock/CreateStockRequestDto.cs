using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Stock
{
    public class CreateStockRequestDto
    {
        [Required, MaxLength(20, ErrorMessage = "Symbol Can Not be more than 10 Character")]
         public string? Symbol { get; set; }
        [Required, MaxLength(20, ErrorMessage = "Company Name Can Not be more than 10 Character")]
        public string? CompanyName { get; set; }
        [Required,Range(1, 1000000000)]
        public decimal Purchase { get; set; }
        [Required, Range(0.001, 10)]
        public decimal LastDiv { get; set; }
        [Required, MaxLength(20, ErrorMessage = "Industry cannot be over 20 character")]
        public string? Industry { get; set; }
        [Range(1, 5000000000)]
        public long MarketCap { get; set; }
    }
}