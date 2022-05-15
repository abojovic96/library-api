using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Models
{
    public class BookDTO
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Title cannot be empty.")]
        public string Title { get; set; }
        public string Author { get; set; }
        public string Genre { get; set; }
        public string Cover { get; set; }
    }
}
