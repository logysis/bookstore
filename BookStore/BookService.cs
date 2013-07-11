using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;

namespace BookStore
{
    public interface IBookService
    {
        IEnumerable<Book> GetBooks();
    }

    public class PhysicalBookService : IBookService
    {
        public IEnumerable<Book> GetBooks()
        {
            return new Book[] { new Book(){ Pages = 300, Title = "Book 1", ISBN = "234232232", PublishDate = DateTime.Today.AddDays(1)},
                                new Book(){ Pages = 322, Title="Book 2", ISBN= "92342342324", PublishDate = DateTime.Today.AddDays(1)}};
        }
    }

    public class BookController
    {
        private IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        public Book GetByISBN(string isbn)
        {
            return _service.GetBooks().SingleOrDefault(p => p.ISBN == isbn);
        }

        public IEnumerable<Book> GetInventory()
        {
            return _service.GetBooks();
        }
    }

    public static class ControllerFactory
    {
        public static BookController GetBookController()
        {
            return DependencyResolver.Resolve<BookController>();
        }
    }
}
