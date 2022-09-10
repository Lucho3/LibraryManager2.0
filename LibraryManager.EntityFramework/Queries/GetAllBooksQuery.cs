using LibraryManager.Domain.Models;
using LibraryManager.Domain.Queries;
using LibraryManager.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.EntityFramework.Queries
{
    public class GetAllBooksQuery : IGetAllBooksQuery
    {
        private readonly BooksDbContextFactory _booksDbContextFactory;

        public GetAllBooksQuery(BooksDbContextFactory booksDbContextFactory)
        {
            _booksDbContextFactory = booksDbContextFactory;
        }

        public async Task<IEnumerable<Book>> Execute()
        {
            using (BooksDbContext context = _booksDbContextFactory.Create())
            {
                IEnumerable<BookDTO> BooksDtos=await context.Books.ToListAsync();

                return BooksDtos.Select(b=> new Book(b.Id,b.Author,b.Date,b.Title,b.Genre,b.Language,b.NPages,b.Quantity,b.QuantityT));
            }
        }
    }
}
