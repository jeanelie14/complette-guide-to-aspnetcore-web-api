using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using my_books.Data.Services;
using my_books.Data.ViewModels;

namespace my_books.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        public BooksServices _BooksServices { get; set; }

        public BooksController(BooksServices booksServices)
        {
            _BooksServices = booksServices;
        }

        [HttpGet("get-all-books")]
        public IActionResult GetAllBooks()
        {
            var allbooks = _BooksServices.GetAllBooks();
            return Ok(allbooks);
        }

        [HttpGet("get-book-by-id/{id}")]
        public IActionResult GetBookById(int id)
        {
            var bookId = _BooksServices.GetBookId(id);
            return Ok(bookId);

        }

        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _BooksServices.AddBook(book);
            return Ok();
        }

        [HttpPut("update-book-by-id/{id}")]
        public IActionResult UpdateBookById(int id, [FromBody] BookVM book)
        {
            var updateBook = _BooksServices.UpdateBook(id, book);
            return Ok(updateBook);
        }


        [HttpDelete("delete-book-by-id/{id}")]
        public IActionResult DeletBook(int id)
        {
            _BooksServices.DeletBookById(id);
            return Ok();
        }
    }
}
