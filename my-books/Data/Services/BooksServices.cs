using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using my_books.Data.Models;
using my_books.Data.ViewModels;

namespace my_books.Data.Services
{
    public class BooksServices
    {
        private AppDbContext _context { get; set; }
        public BooksServices(AppDbContext context)
        {
            _context = context;
        }


        public void AddBookWithAuthors(BookVM book)
        {
            var _book = new Book()
            {
                Title = book.Title,
                Description = book.Description,
                IsRead = book.IsRead,
                DateRead = book.IsRead? book.DateRead.Value:null,
                Rate = book.IsRead? book.Rate.Value:null,
                Genre = book.Genre,
                CoverUrl = book.CoverUrl,
                DateAdded = DateTime.Now,
                PublisherId = book.PublisherId,
            };
            _context.Books.Add(_book);
            _context.SaveChanges();

            foreach (var id in book.AuthorIds)
            {
                var _book_author = new Book_Author()
                {
                    BookId = _book.Id,
                    AuthorId = id
                };
                _context.Book_Authors.Add(_book_author);
               _context.SaveChanges();
            }
        }


        public List<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }


        public Book GetBookId(int bookid)
        {
            return _context.Books.FirstOrDefault(n=>n.Id== bookid);
        }

        public Book UpdateBook(int bookid, BookVM book)
        {
            var _book = _context.Books.FirstOrDefault(n => n.Id == bookid);
            if (_book != null)
            {
                _book.Title = book.Title;
                _book.Description = book.Description;
                _book.IsRead = book.IsRead;
                _book. DateRead = book.IsRead ? book.DateRead.Value : null;
                _book.Rate = book.IsRead ? book.Rate.Value : null;
                _book. Genre = book.Genre;
                _book. CoverUrl = book.CoverUrl;

                _context.SaveChanges();
            }
            return _book;
        }

        public void DeletBookById(int bookid)
        {
            var book = _context.Books.FirstOrDefault(i
            => i.Id== bookid);

            if (book != null)
            {
                _context.Books.Remove(book);
                _context.SaveChanges();
            }
        }
    }
}
