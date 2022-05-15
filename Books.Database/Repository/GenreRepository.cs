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
    public class GenreRepository : BaseRepository, IGenreRepository
    {
        public GenreRepository(AppDbContext context) : base(context) { }

        public int Add(Genre genre)
        {
            Add<Genre>(genre);
            return genre.Id;
        }

        public IEnumerable<Genre> GetAll()
        {
            return _context.Genres.AsEnumerable();
        }

        public Genre GetByName(string name)
        {
            var genre = _context.Genres.FirstOrDefault(x => x.Name == name);
            return genre;
        }
    }
}
