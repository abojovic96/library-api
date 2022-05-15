using AutoMapper;
using Books.Database.Models;
using Books.Database.Repository.Interfaces;
using Books.Logic.Interfaces;
using Books.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Books.Logic
{
    public class BookLogic : IBookLogic
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IAuthorRepository _authorRepository;
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookLogic(IGenreRepository genreRepository, IAuthorRepository authorRepository, IBookRepository bookRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _authorRepository = authorRepository;
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public void Add(BookLogicModel blm)
        {

            int authorId = findAuthorId(blm.AuthorName);
            int genreId = findGenreId(blm.GenreName);

            var book = new Book()
            {
                Title = blm.Title,
                Price = blm.Price,
                Summery = blm.Summery,
                AuthorId = authorId,
                GenreId = genreId,
                Cover = blm.Cover
            };

            _bookRepository.Add(book);
        }

        public IEnumerable<BookLogicModel> FilterByGenre(int genreId)
        {
            var booksByGenre = _bookRepository.FilterByGenre(genreId);
            var booksMapped = _mapper.Map<IEnumerable<BookLogicModel>>(booksByGenre);
            return booksMapped;
        }

        public IEnumerable<BookLogicModel> GetAll()
        {
            var books = _bookRepository.GetAll();
            var booksMapped = _mapper.Map<IEnumerable<BookLogicModel>>(books);
            return booksMapped;
        }

        public BookLogicModel GetById(int id)
        {
            var book = _bookRepository.GetById(id);
            var bookMapped = _mapper.Map<BookLogicModel>(book);
            return bookMapped;
        }

        public bool Remove(int id)
        {
            var book = _bookRepository.GetById(id);
            if(book == null)
            {
                return false;
            }
            _bookRepository.Remove(book);
            return true;
        }

        public IEnumerable<BookLogicModel> SearchByName(string search)
        {
            var searchedBooks = _bookRepository.SearchByName(search);
            var booksMapped = _mapper.Map<IEnumerable<BookLogicModel>>(searchedBooks);
            return booksMapped;
        }

        public bool Update(BookLogicModel blm)
        {
            var book = _mapper.Map<Book>(blm);
            try
            {
                _bookRepository.Update(book);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private int findAuthorId(string author)
        {
            var tokens = author.Split("+");
            string authorName = tokens[0];
            string authorSurname = tokens[1];
            var foundAuthor = _authorRepository.GetByName(authorName, authorSurname);

            var authorId = 0;
            if (foundAuthor == null)
            {
                Author newAuthor = new Author()
                {
                    FirstName = authorName,
                    LastName = authorSurname
                };

                authorId = _authorRepository.Add(newAuthor);
            }
            else
            {
                authorId = foundAuthor.Id;
            }

            return authorId;
        }

        private int findGenreId(string genre)
        {
            var foundGenre = _genreRepository.GetByName(genre);

            var genreId = 0;
            if (foundGenre == null)
            {
                Genre newGenre = new Genre()
                {
                    Name = genre
                };

                genreId = _genreRepository.Add(newGenre);
            }
            else
            {
                genreId = foundGenre.Id;
            }

            return genreId;
        }
    }
}
