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
    public class AuthorLogic : IAuthorLogic
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public AuthorLogic(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public void AddAuthor(AuthorLogicModel alm)
        {
            var author = _mapper.Map<Author>(alm);
            _authorRepository.Add(author);
        }

        public IEnumerable<AuthorLogicModel> GetAll()
        {
            var authors = _authorRepository.GetAll();
            var mappedAuthors = _mapper.Map<List<AuthorLogicModel>>(authors);
            return mappedAuthors;
        }
    }
}
