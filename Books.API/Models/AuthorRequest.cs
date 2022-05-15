using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Models
{
    public class AuthorRequest
    {
        [Required (ErrorMessage = "Authors first name cannot be empty.")]
        public string FirstName { get; set; }
        //IN CASE OF MONONYMOUS AUTHORS (ARISOTLE, PLATO ETC.), THIS FIELD CAN BE EMPTY.
        public string LastName { get; set; }
    }
}
