using my_books.Data.Models;
using my_books.Data.ViewModels;
using System;

namespace my_books.Data.Services
{
    public class PublisherService
    {
        private AppDbContext _context { get; set; }
        public PublisherService(AppDbContext context)
        {
            _context = context;
        }
        public void AddPublisher(PublisherVM publisher)
        {
            var _publisher = new Publisher()
            {
              Name= publisher.Name,
            };
            _context.Publishers.Add(_publisher);
            _context.SaveChanges();
        }
    }
}
