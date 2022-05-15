using AutoMapper;
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
    public class GenreLogic : IGenreLogic
    {
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;
        public GenreLogic(IGenreRepository genreRepository, IMapper mapper)
        {
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public IEnumerable<GenreLogicModel> GetAllGenres()
        {
            var genres = _genreRepository.GetAll();
            var mappedGenres = _mapper.Map<IEnumerable<GenreLogicModel>>(genres);
            return mappedGenres;
        }
    }
}
