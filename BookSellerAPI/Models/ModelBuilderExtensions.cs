using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookSellerAPI.Models
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, FirstName = "William", LastName = "Bailey", BookId = 2, DateOfBirth = DateTime.Parse("1965-07-09") },
                new Author { Id = 2, FirstName = "Henry", LastName = "Thomas", BookId = 1, DateOfBirth = DateTime.Parse("1995-07-09") },
                new Author { Id = 3, FirstName = "Jack", LastName = "Douglas", BookId = 2, DateOfBirth = DateTime.Parse("1961-07-09") },
                new Author { Id = 4, FirstName = "Joseph ", LastName = "Carter", BookId = 3, DateOfBirth = DateTime.Parse("1971-07-09") },
                new Author { Id = 5, FirstName = "Marco  ", LastName = "Willis", BookId = 6, DateOfBirth = DateTime.Parse("1981-05-04") },
                new Author { Id = 6, FirstName = "Ryan", LastName = "Rios", BookId = 3, DateOfBirth = DateTime.Parse("1966-05-04") },
                new Author { Id = 7, FirstName = "Mark", LastName = "Hobbs", BookId = 6, DateOfBirth = DateTime.Parse("1986-03-04") },
                new Author { Id = 8, FirstName = "Abraham", LastName = "Jenkins", BookId = 3, DateOfBirth = DateTime.Parse("1970-03-04") },
                new Author { Id = 9, FirstName = "Odin", LastName = "Snyder", BookId = 7, DateOfBirth = DateTime.Parse("1970-03-09") },
                new Author { Id = 10, FirstName = "Sonny", LastName = "Avila", BookId = 1, DateOfBirth = DateTime.Parse("1995-07-09") }
            );
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, BookGenre = Genre.History, Title = "Heroes Of Dawn", AuthorId = 1, BestSeller = true, ReleaseDate = DateTime.Parse("1969-07-09"), Price = 95 },
                new Book { Id = 2, BookGenre = Genre.Fiction, Title = "Goal With Money", AuthorId = 1, BestSeller = true, ReleaseDate = DateTime.Parse("2014-07-09"), Price = 20 },
                new Book { Id = 3, BookGenre = Genre.History, Title = "Blacksmiths And Butchers", AuthorId = 1, BestSeller = true, ReleaseDate = DateTime.Parse("2001-07-09"), Price = 70 },
                new Book { Id = 4, BookGenre = Genre.NonFiction, Title = "Altering The West", AuthorId = 1, BestSeller = true, ReleaseDate = DateTime.Parse("2012-07-09"), Price = 55 },
                new Book { Id = 5, BookGenre = Genre.History, Title = "Traitor Of The Banished", AuthorId = 1, BestSeller = true, ReleaseDate = DateTime.Parse("1998-07-09"), Price = 50 },
                new Book { Id = 6, BookGenre = Genre.NonFiction, Title = "Inventing The Void", AuthorId = 1, BestSeller = false, ReleaseDate = DateTime.Parse("1970-07-09"), Price = 30 },
                new Book { Id = 7, BookGenre = Genre.Fiction, Title = "Crossbow Without Time", AuthorId = 3, BestSeller = false, ReleaseDate = DateTime.Parse("2015-02-05"), Price = 35 },
                new Book { Id = 8, BookGenre = Genre.History, Title = "Butchers Of Time", AuthorId = 3, BestSeller = false, ReleaseDate = DateTime.Parse("2000-02-12"), Price = 15 },
                new Book { Id = 9, BookGenre = Genre.Fiction, Title = "Robots Of Insanity", AuthorId = 3, BestSeller = false, ReleaseDate = DateTime.Parse("2010-02-12"), Price = 75 },
                new Book { Id = 10, BookGenre = Genre.NonFiction, Title = "Heroes And Assassins", AuthorId = 3, BestSeller = false, ReleaseDate = DateTime.Parse("2017-09-12"), Price = 49 },
                new Book { Id = 11, BookGenre = Genre.History, Title = "Fish Of Sorrow", AuthorId = 3, BestSeller = false, ReleaseDate = DateTime.Parse("1990-09-12"), Price = 45 },
                new Book { Id = 12, BookGenre = Genre.History, Title = "Foe With Immortality", AuthorId = 3, BestSeller = true, ReleaseDate = DateTime.Parse("1991-03-05"), Price = 39 },
                new Book { Id = 13, BookGenre = Genre.NonFiction, Title = "Snakes And Kings", AuthorId = 3, BestSeller = true, ReleaseDate = DateTime.Parse("2013-03-04"), Price = 19 },
                new Book { Id = 14, BookGenre = Genre.History, Title = "Jumping Into Secrets", AuthorId = 2, BestSeller = true, ReleaseDate = DateTime.Parse("2016-03-04"), Price = 24 },
                new Book { Id = 15, BookGenre = Genre.NonFiction, Title = "Force Of The Dark", AuthorId = 2, BestSeller = true, ReleaseDate = DateTime.Parse("2016-03-04"), Price = 79 },
                new Book { Id = 17, BookGenre = Genre.History, Title = "Death Of Fire", AuthorId = 2, BestSeller = true, ReleaseDate = DateTime.Parse("2017-04-04"), Price = 65 }
            );
        }
    }

}
