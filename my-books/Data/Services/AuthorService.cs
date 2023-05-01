using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;

namespace my_books.Data.Services
{
    public class AuthorService
    {
        private AppDbContext _context { get; set; }
        public AuthorService(AppDbContext context)
        {
            _context = context;
        }
        public void AddAuthor(AuthorVM autor)
        {
            var _author = new Author()
            {
               FullName = autor.FullName
            };
            _context.Authors.Add(_author);
            _context.SaveChanges();
        }
    }
}
