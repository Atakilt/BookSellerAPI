using BookSellerAPI.Common;
using BookSellerAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Linq.Dynamic.Core;
using Microsoft.AspNetCore.Authorization;

namespace BookSellerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogueController : ControllerBase
    {
        private readonly BookSellerContext _context;
        public CatalogueController(BookSellerContext context)
        {
            _context = context;
            _context.Database.EnsureCreated();
        }

        [HttpGet]
        [Route("authors")]
        public async Task<IActionResult> GetAllAuthors([FromQuery] QueryParameters queryParameters)
        {
            IQueryable<Author> authors = _context.Authors;
            authors = queryParameters.Size > 0 ? authors.Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size) : authors;

            return Ok(await authors.ToArrayAsync());
        }

        [HttpGet]
        [Route("books")]
        public async Task<IActionResult> GetAllBooks([FromQuery] BookQueryParameters queryParameters)
        {
            IQueryable<Book> books = _context.Books;

            if(queryParameters.MinPrice >= 0 && queryParameters.MaxPrice > 0)
            {
                books = books.Where(b => b.Price >= queryParameters.MinPrice &&
                                       b.Price <= queryParameters.MaxPrice);
            }

            if(queryParameters.Genre != null)
            {
                books = books.Where(b => string.Equals(b.BookGenre.ToString(), queryParameters.Genre,
                    StringComparison.CurrentCultureIgnoreCase));
            }

            if(queryParameters.Title !=null)
            {
                books = books.Where(b => b.Title.ToLower().Contains(queryParameters.Title.ToLower()));
            }

            if (queryParameters.SortBy != null)
            {
                var sortOrder = queryParameters.IsAscending ? "ascending" : "descending";
                books = books.AsQueryable().OrderBy(queryParameters.SortBy + " " + sortOrder);
            }

            books = queryParameters.Size > 0 ? books.Skip(queryParameters.Size * (queryParameters.Page - 1))
                .Take(queryParameters.Size) : books;

            return Ok(await books.ToArrayAsync());
        }

        [HttpGet]
        [Route("authors/{id:int}")]
        public async Task<IActionResult> GetAllAuthors(int id)
        {
            var author = await _context.Authors.FindAsync(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpPost]
        [Route("book")]
        public async Task<ActionResult<Book>> CreateBook([FromBody] Book book)
        {
            _context.Books.Add(book);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAllBooks", 
                new { id = book.Id }, book);
        }

        [HttpPut]
        [Route("book/{id:int}")]
        public async Task<ActionResult<Book>> UpdateBook(int id, [FromBody] Book book)
        {
            var isBookFound = await _context.Books.FindAsync(id);

            if (isBookFound == null)
            {
                return NotFound();
            }

            _context.Entry(book).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException e)
            {
                if(_context.Books.Find(id) == null)
                {
                    return NotFound();

                }               
                throw;
            }

            return NoContent();
        }

        [HttpDelete]
        [Route("book/{id:int}")]
        public async Task<ActionResult<Book>> DeleteBook(int id)
        {
            var book = await _context.Books.FindAsync(id);

            if(book == null)
            {
                return NotFound();
            }

            _context.Books.Remove(book);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}

