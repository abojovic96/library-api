using Books.Database.Models;
using Books.Database.Models.Contexts;
using Books.Database.Repository.Base;
using Books.Database.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Database.Repository
{
    public class AuthorRepository : BaseRepository, IAuthorRepository
    {
        public AuthorRepository(AppDbContext context) : base(context) { }

        public int Add(Author author)
        {
            Add<Author>(author);
            return author.Id;
        }

        public IEnumerable<Author> GetAll()
        {
            return _context.Authors.AsEnumerable();
        }

        public Author GetByName(string name, string surname)
        {
            var author = _context.Authors.SingleOrDefault(a => a.FirstName == name && a.LastName == surname);
            return author;
        }
    }
}
