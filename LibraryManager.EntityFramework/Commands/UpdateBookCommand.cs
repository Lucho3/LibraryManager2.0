using LibraryManager.Domain.Commands;
using LibraryManager.Domain.Models;
using LibraryManager.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.EntityFramework.Commands
{
    public class UpdateBookCommand:IUpdateBookCommand
    {
        private readonly BooksDbContextFactory _booksDbContextFactory;

        public UpdateBookCommand(BooksDbContextFactory booksDbContextFactory)
        {
            _booksDbContextFactory = booksDbContextFactory;
        }

        public async Task Execute(Book book)
        {
            using (BooksDbContext context = _booksDbContextFactory.Create())
            {
                BookDTO bookDTO = new BookDTO()
                {
                    Id = book.Id,
                    Author = book.Author,
                    Date = book.Date,
                    Title = book.Title,
                    Genre = book.Genre,
                    Language = book.Language,
                    NPages = book.NPages,
                    Quantity = book.Quantity,
                    QuantityT = book.QuantityT
                };

                context.Books.Update(bookDTO);
                await context.SaveChangesAsync();
            }
        }
    }
}
