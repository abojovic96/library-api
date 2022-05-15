using AutoMapper;
using Books.API.Models;
using Books.Logic.Interfaces;
using Books.Logic.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Books.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly IAuthorLogic _authorLogic;
        private readonly IMapper _mapper;

        public AuthorsController(IAuthorLogic authorLogic, IMapper mapper)
        {
            _authorLogic = authorLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAllAuthors()
        {
            var allAuthors = _authorLogic.GetAll();
            var mappedAuthors = _mapper.Map<IEnumerable<AuthorDTO>>(allAuthors);
            return Ok(mappedAuthors);
        }

        [HttpPost]
        public IActionResult AddAuthor(AuthorRequest author)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newAuthor = _mapper.Map<AuthorLogicModel>(author);
            _authorLogic.AddAuthor(newAuthor);
            return Ok();
        }
    }
}
