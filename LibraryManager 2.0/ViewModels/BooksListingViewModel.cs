using LibraryManager_2._0.Models;
using LibraryManager_2._0.Stores;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public BooksListingViewModel(SelctedBookStore _selctedBookStore)
        {
            selctedBookStore = _selctedBookStore;
            _booksListingItemViewModel = new ObservableCollection<BooksListingItemViewModel>();

            _booksListingItemViewModel.Add(new BooksListingItemViewModel(new Book("a1","d1","t1","g1","l1",5,5,5)));
            _booksListingItemViewModel.Add(new BooksListingItemViewModel(new Book("a1", "d1", "t2", "g1", "l1", 5, 5, 5)));
            _booksListingItemViewModel.Add(new BooksListingItemViewModel(new Book("a1", "d1", "t3", "g1", "l1", 5, 5, 5)));
          
        }
    }
}
