using Books.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Database.Repository.Interfaces
{
    public interface IAuthorRepository
    {
        IEnumerable<Author> GetAll();
        int Add(Author author);
        Author GetByName(string name, string surname);
    }
}
