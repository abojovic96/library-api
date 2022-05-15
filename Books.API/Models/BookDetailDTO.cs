using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Models
{
    public class BookDetailDTO : BookDTO
    {
        [Required(ErrorMessage = "Price is required.")]
        [Range(0.1, double.MaxValue, ErrorMessage = "Please enter valid price (>0)")]
        public double Price { get; set; }
        [StringLength(450, ErrorMessage = "Summary must be shorted then 450 characters.")]
        public string Summery { get; set; }
    }
}
