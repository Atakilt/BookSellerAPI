using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSellerAPI.Common
{
    public class BookQueryParameters : QueryParameters
    {
        public string Genre { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
        public string Title { get; set; }
        public string SortBy { get; set; }
        public bool IsAscending { get; set; } = true;
    }
}
