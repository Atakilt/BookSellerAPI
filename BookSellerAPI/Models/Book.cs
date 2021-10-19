using System;
using System.ComponentModel.DataAnnotations;

namespace BookSellerAPI.Models
{
    public enum Genre
    {
        Fiction,
        NonFiction,
        History
    }
    public class Book
    {
        public int Id { get; set; }
        public DateTime ReleaseDate { get; set; }
        public int AuthorId { get; set; }
        [Required(ErrorMessage = "Please enter book title" )]
        [StringLength(30,MinimumLength = 1, ErrorMessage ="Book title should be 1 and 30 characters")]
        public string Title { get; set; }
        public bool BestSeller { get; set; }
        public decimal Price { get; set; }
        public Genre BookGenre { get; set; }
    }
}
