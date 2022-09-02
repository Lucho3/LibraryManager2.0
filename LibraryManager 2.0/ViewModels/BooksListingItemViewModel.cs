using LibraryManager_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManager_2._0.ViewModels
{
    class BooksListingItemViewModel : ViewModelBase
    {
        public Book Book { get; }

        public string Author => Book.Author;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }


        public BooksListingItemViewModel(Book book)
        {
            Book = book;
        }
    }
}