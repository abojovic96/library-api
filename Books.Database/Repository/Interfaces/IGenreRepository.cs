using Books.Database.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Database.Repository.Interfaces
{
    public interface IGenreRepository
    {

        int Add(Genre genre);
        IEnumerable<Genre> GetAll();

        Genre GetByName(string name);
    }
}
