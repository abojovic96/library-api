using Books.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic.Interfaces
{
    public interface IGenreLogic
    {
        IEnumerable<GenreLogicModel> GetAllGenres();
    }
}
