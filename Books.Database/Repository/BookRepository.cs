using Books.Database.Models;
using Books.Database.Models.Contexts;
using Books.Database.Repository.Base;
using Books.Database.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Database.Repository
{
    public class BookRepository : BaseRepository, IBookRepository
    {
        public BookRepository(AppDbContext context) : base(context) { }

        public void Add(Book book) => Add<Book>(book);

        public IEnumerable<Book> FilterByGenre(int genreId)
        {
            return _context.Books.Include(b => b.Author).Include(b => b.Genre).Where(b => b.GenreId == genreId).AsEnumerable();

        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books.Include(b => b.Author).Include(b => b.Genre).AsEnumerable();
        }

        public Book GetById(int id)
        {
            return _context.Books.Include(b => b.Author).Include(b => b.Genre).SingleOrDefault(b => b.Id == id);
        }

        public void Remove(Book book) => Remove<Book>(book);

        public IEnumerable<Book> SearchByName(string search)
        {
            return _context.Books.Include(b => b.Author).Include(b => b.Genre).Where(b => b.Title.ToLower().Contains(search.Trim().ToLower())).AsEnumerable();
        }

        public void Update(Book book) => Update<Book>(book);
    }
}
