using LibraryManager.Domain.Commands;
using LibraryManager.Domain.Models;
using LibraryManager.Domain.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Stores
{
    class BooksStore
    {
        private readonly IGetAllBooksQuery _getAllBooksQuery;
        private readonly ICreateBookCommand _createBookCommand;
        private readonly IUpdateBookCommand _updateBookCommand;
        private readonly IDeleteBookCommand _deleteBookCommand;

        public BooksStore(IGetAllBooksQuery getAllBooksQuery, ICreateBookCommand createBookCommand, IUpdateBookCommand updateBookCommand, IDeleteBookCommand deleteBookCommand)
        {
            _getAllBooksQuery = getAllBooksQuery;
            _createBookCommand = createBookCommand;
            _updateBookCommand = updateBookCommand;
            _deleteBookCommand = deleteBookCommand;
        }

        public event Action<Book> BookAdded;
        public event Action<Book> BookUpdated;

        public async Task Add(Book book)
        {
            await _createBookCommand.Execute(book);

            BookAdded?.Invoke(book);
        }

        public async Task Update(Book book)
        {
            await _updateBookCommand.Execute(book);

            BookUpdated?.Invoke(book);
        }


    }
}
