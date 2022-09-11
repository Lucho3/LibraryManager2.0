﻿using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Stores
{
    class SelctedBookStore
    {
        private readonly BooksStore _bookStore;

        private Book _selectedBook;

        public SelctedBookStore(BooksStore bookStore)
        {
            _bookStore = bookStore;

            _bookStore.BookUpdated += _bookStore_BookUpdated;
            _bookStore.BookDeleted += _bookStore_BookDeleted;
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
