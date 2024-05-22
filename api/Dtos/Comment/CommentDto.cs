using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CommentDto
    {
         public int Id { get; set; }
        public string? Titel { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedOn { get; set; }
        public int StockId { get; set; }
    }
}