using Books.Database.Models;
using Books.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic.Interfaces
{
    public interface IBookLogic
    {
        IEnumerable<BookLogicModel> GetAll();
        BookLogicModel GetById(int id);
        void Add(BookLogicModel blm);
        bool Remove(int id);
        bool Update(BookLogicModel blm);
        IEnumerable<BookLogicModel> FilterByGenre(int genreId);
        IEnumerable<BookLogicModel> SearchByName(string search);
    }
}
