using LibraryManager_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Stores
{
    class SelctedBookStore
    {
        private Book _selectedBook;

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
