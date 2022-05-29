using AutoMapper;
using Books.API.Models;
using Books.Logic.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    // Controller used for handling genres.
    [Route("api/[controller]")]
    [ApiController]
    public class GenresController : ControllerBase
    {
        private readonly IGenreLogic _genreLogic;
        private readonly IMapper _mapper;

        public GenresController(IGenreLogic genreLogic, IMapper mapper)
        {
            _genreLogic = genreLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllGenres()
        {
            var genres = _genreLogic.GetAllGenres();
            var genresMapped = _mapper.Map<IEnumerable<GenreDTO>>(genres);
            return Ok(genresMapped);
        }
    }
}
