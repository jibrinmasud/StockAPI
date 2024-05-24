using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    [Table("Stocks")]
    public class Stock
    {
        
        public int Id { get; set;}
        public string? Symbol { get; set; }
        public string? CompanyName { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal Purchase { get; set; }
        [Column(TypeName ="decimal(18,2)")]
        public decimal LastDiv { get; set; }
        public string? Industry { get; set; }
        public long MarketCap { get; set; }
        public List<Comment>? comments  { get; set; }
          public List<Portfolio> Portfolios  { get; set; } = new List<Portfolio>(); 

    }
}