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
                _BooksServices= booksServices;  
        }

        [HttpPost ("add-book")]
        public IActionResult AddBook([FromBody] BookVM book)
        {
            _BooksServices.AddBook(book);
            return Ok();
        }

    }
}
