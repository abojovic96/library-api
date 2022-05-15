using Books.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Database.Repository.Interfaces
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        void Add(Book book);
        void Remove(Book book);
        void Update(Book book);
        IEnumerable<Book> FilterByGenre(int genreId);
        IEnumerable<Book> SearchByName(string search);
    }
}
