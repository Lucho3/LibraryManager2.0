using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Stores
{
    class SelectedBookStore
    {
        private readonly BooksStore _bookStore;

        private Book _selectedBook;

        public SelectedBookStore(BooksStore bookStore)
        {
            _bookStore = bookStore;

            _bookStore.BookUpdated += _bookStore_BookUpdated;
            _bookStore.BookDeleted += _bookStore_BookDeleted;
            _bookStore.BookAdded += _bookStore_BookAdded;
        }

        private void _bookStore_BookAdded(Book obj)
        {
            SelectedBook = obj;
        }

        private void _bookStore_BookDeleted(Guid obj)
        {
            SelectedBook = null;
        }

        
        private void _bookStore_BookUpdated(Book obj)
        {
           if(obj.Id==_selectedBook?.Id)
            {
                SelectedBook = obj;
            }
        }

        public Book SelectedBook
        {
            get 
            { 
                return _selectedBook; 
            }
            set 
            {
                _selectedBook = value;
                SelectedBookChanged?.Invoke();
            }
        }

        public event Action SelectedBookChanged;

    }
}
