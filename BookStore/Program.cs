using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.Practices.Unity;

namespace BookStore
{
    class Program
    {
        static void Main(string[] args)
        {
            BootStrap.Initialize();

            BookController controller = ControllerFactory.GetBookController();
            var books = controller.GetInventory();
            books.ToList().ForEach(b => Console.WriteLine(b.Title + " " + b.ISBN));
            Console.ReadLine();
        }
    }
}
