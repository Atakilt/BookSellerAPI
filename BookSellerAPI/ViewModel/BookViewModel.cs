using BookSellerAPI.Models;
using System.Collections.Generic;

namespace BookSellerAPI.ViewModel
{
    public class BookViewModel
    {
        public IEnumerable<Book> Books { get; set; }
    }
}
