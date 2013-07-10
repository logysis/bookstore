using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookStore
{
    class Program
    {
        static BookController _bookController;

        static void Main(string[] args)
        {
            Initialize();

            var books = _bookController.GetInventory();
            books.ToList().ForEach(b => Console.WriteLine(b.Title + " " + b.ISBN));
            Console.ReadLine();
        }

        static void Initialize()
        {
            _bookController = new BookController(new PhysicalBookService());

        }
    }
}
