using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace BookStore
{
    public class Book
    {
        public string Title { get; set; }
        public int Pages { get; set; }
        public string ISBN { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
