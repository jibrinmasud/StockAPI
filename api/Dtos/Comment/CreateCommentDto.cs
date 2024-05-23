using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Comment
{
    public class CreateCommentDto
    {
        [Required, MinLength(5, ErrorMessage = "Title Must be 5 Characters")]
        [MaxLength(280, ErrorMessage="Title Can Not Be More Than 280 Character")]
        public string? Titel { get; set; }
        [Required, MinLength(5, ErrorMessage = "Content Must be 5 Characters")]
        [MaxLength(280, ErrorMessage="Content Can Not Be More Than 280 Character")]

        public string? Content { get; set; }
    }
}