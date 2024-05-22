using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Comment;

namespace api.Dtos.Stock
{
    public class StockDto
    {
         public int Id { get; set;}
        public string? Symbol { get; set; }
        public string? CompanyName { get; set; }
       
        public decimal Purchase { get; set; }
        
        public decimal LastDiv { get; set; }
        public string? Industry { get; set; }
        public long MarketCap { get; set; } 
        public List<CommentDto> comments{get; set;}    
    }
}