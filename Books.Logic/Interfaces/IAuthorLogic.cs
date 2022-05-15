using Books.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic.Interfaces
{
    public interface IAuthorLogic
    {
        IEnumerable<AuthorLogicModel> GetAll();
        void AddAuthor(AuthorLogicModel alm);
    }
}
