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
        private readonly List<Book> _books;

        public BooksStore(IGetAllBooksQuery getAllBooksQuery, ICreateBookCommand createBookCommand, IUpdateBookCommand updateBookCommand, IDeleteBookCommand deleteBookCommand)
        {
            _getAllBooksQuery = getAllBooksQuery;
            _createBookCommand = createBookCommand;
            _updateBookCommand = updateBookCommand;
            _deleteBookCommand = deleteBookCommand;

            _books = new List<Book>();
        }

        public event Action<Book> BookAdded;
        public event Action<Book> BookUpdated;
        public event Action<Guid> BookDeleted;

        public IEnumerable<Book> Books => _books;

        public event Action BooksLoaded;

        public async Task Load()
        {
            IEnumerable<Book> books = await _getAllBooksQuery.Execute();
            _books.Clear();

            _books.AddRange(books);

            BooksLoaded?.Invoke();

        }

        public async Task Add(Book book)
        {
            await _createBookCommand.Execute(book);

            _books.Add(book);

            BookAdded?.Invoke(book);
        }

        public async Task Update(Book book)
        {
            await _updateBookCommand.Execute(book);

            int currentIndex=_books.FindIndex(b => b.Id == book.Id);

            if(currentIndex!=-1)
            {
                _books[currentIndex] = book;
            }
            else
            {
                _books.Add(book);
            }

            BookUpdated?.Invoke(book);
        }

        public async Task Delete(Guid Id)
        {
            await _deleteBookCommand.Execute(Id);

            _books.RemoveAll(b => b.Id == Id);

            BookDeleted?.Invoke(Id);
        }
    }
}
