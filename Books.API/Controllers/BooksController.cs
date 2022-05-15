using AutoMapper;
using Books.API.Models;
using Books.Logic.Interfaces;
using Books.Logic.Models;
using Microsoft.AspNetCore.Authorization;
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
    public class BooksController : ControllerBase
    {
        private readonly IBookLogic _bookLogic;
        private readonly IMapper _mapper;

        public BooksController(IBookLogic bookLogic, IMapper mapper)
        {
            _bookLogic = bookLogic;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var allBooks = _bookLogic.GetAll();
            var booksMapped = _mapper.Map<IEnumerable<BookDTO>>(allBooks);
            return Ok(booksMapped);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            if (id <= 0)
            {
                return BadRequest(new MessageWrapper("Please enter valid ID"));
            }
            var book = _bookLogic.GetById(id);
            if (book == null)
            {
                return NotFound(new MessageWrapper("Could not find a book with that ID"));
            }
            return Ok(_mapper.Map<BookDetailDTO>(book));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            if(id <= 0)
            {
                return BadRequest(new MessageWrapper("Please enter valid ID"));
            }

            var wasItDeleted = _bookLogic.Remove(id);

            if (!wasItDeleted)
            {
                return NotFound(new MessageWrapper("Could not find a book with that ID"));
            }
            return NoContent();
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddBook(BookDetailDTO br)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newBook = _mapper.Map<BookLogicModel>(br);
            _bookLogic.Add(newBook);
            return CreatedAtAction("GetById", new { id = newBook.Id }, newBook);
        }

        [Authorize]
        [HttpPut("{id}")]
        public IActionResult PutBook([FromQuery] int id, [FromBody] BookDetailDTO br)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if(id != br.Id)
            {
                return BadRequest();
            }

            var putBook = _mapper.Map<BookLogicModel>(br);
            var wasItPut = _bookLogic.Update(putBook);
            if (!wasItPut)
            {
                return BadRequest();
            }
            return Ok(_mapper.Map<BookDetailDTO>(putBook));
        }

        [HttpGet]
        [Route("genre")]
        public IActionResult FilterByGenre([FromQuery] int id)
        {
            if (id <= 0)
            {
                return BadRequest("Please enter valid ID");
            }

            var booksByGenre = _bookLogic.FilterByGenre(id);
            var mappedBooks = _mapper.Map<IEnumerable<BookDTO>>(booksByGenre);
            return Ok(mappedBooks);
        }

        [HttpGet]
        [Route("search")]
        public IActionResult SearchByName([FromQuery] string find)
        {
            if(find.Trim().Length == 0)
            {
                return BadRequest("Please enter valid search parametar.");
            }

            var searchedBooks = _bookLogic.SearchByName(find.Trim());
            var mappedBooks = _mapper.Map<IEnumerable<BookDTO>>(searchedBooks);
            return Ok(mappedBooks);
        }
    }
}
