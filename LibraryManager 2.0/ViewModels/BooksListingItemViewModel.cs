using LibraryManager_2._0.Commands;
using LibraryManager.Domain.Models;
using LibraryManager_2._0.Stores;
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
        public BooksListingItemViewModel(Book book, BooksStore booksStore, ModalNavigationStore modalNavigationStore)
        {
            Book = book;
            EditCommand = new OpenEditBookCommand(this,booksStore,modalNavigationStore);
            DeleteCommand = new DeleteBookCommand(this, booksStore);
        }

        public Book Book { get; private set; }

        public string Title => Book.Title;

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }
        public BooksStore BooksStore { get; }
        public ModalNavigationStore ModalNavigationStore { get; }

        private bool _isDeleting;
        public bool IsDeleting
        {
            get
            {
                return _isDeleting;
            }
            set
            {
                _isDeleting = value;
                OnPropertyChanged(nameof(IsDeleting));
            }
        }
        public void Update(Book obj)
        {
            Book = obj;
            OnPropertyChanged(nameof(Title));
        }
    }
}