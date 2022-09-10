using LibraryManager.Domain.Commands;
using LibraryManager.EntityFramework.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.EntityFramework.Commands
{
    public class DeleteBookCommand:IDeleteBookCommand
    {
        private readonly BooksDbContextFactory _booksDbContextFactory;

        public DeleteBookCommand(BooksDbContextFactory booksDbContextFactory)
        {
            _booksDbContextFactory = booksDbContextFactory;
        }

        public async Task Execute(Guid id)
        {
            using (BooksDbContext context = _booksDbContextFactory.Create())
            { 
                context.Books.Remove(new BookDTO { Id=id, });
                await context.SaveChangesAsync();
            }
        }
    }
}
