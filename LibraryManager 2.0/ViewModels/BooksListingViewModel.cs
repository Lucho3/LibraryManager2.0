using LibraryManager_2._0.Commands;
using LibraryManager_2._0.Models;
using LibraryManager_2._0.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManager_2._0.ViewModels
{
    class BooksListingViewModel:ViewModelBase
    {
        private readonly ObservableCollection<BooksListingItemViewModel> _booksListingItemViewModel;
        private readonly SelctedBookStore selctedBookStore;

        public IEnumerable<BooksListingItemViewModel> BooksListingItemViewModels => _booksListingItemViewModel;

        private BooksListingItemViewModel selectedBookListingItemViewModel;

        public BooksListingItemViewModel SelectedBookListingItemViewModel
        {
            get 
            {
                return selectedBookListingItemViewModel;
            }
            set 
            {
                selectedBookListingItemViewModel = value;
                OnPropertyChanged(nameof(SelectedBookListingItemViewModel));
                selctedBookStore.SelectedBook = SelectedBookListingItemViewModel?.Book;
            }
        }

        public BooksListingViewModel(SelctedBookStore _selctedBookStore,ModalNavigationStore modalNavigationStore)
        {
            selctedBookStore = _selctedBookStore;
            _booksListingItemViewModel = new ObservableCollection<BooksListingItemViewModel>();

            AddBook(new Book("a1", "22.11.2021", "t1", "g1", "l1", 5, 5, 5), modalNavigationStore);
            AddBook(new Book("a1", "d1", "t2", "g1", "l1", 5, 5, 5), modalNavigationStore);
            AddBook(new Book("a1", "d1", "t3", "g1", "l1", 5, 5, 5), modalNavigationStore);

          
        }

        private void AddBook(Book book, ModalNavigationStore modalNavigationStore)
        {
            ICommand editCommand = new OpenEditBookCommand(book,modalNavigationStore);
            _booksListingItemViewModel.Add(new BooksListingItemViewModel(book,editCommand));
        }
    }
}
