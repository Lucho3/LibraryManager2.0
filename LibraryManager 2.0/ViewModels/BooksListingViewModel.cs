using LibraryManager_2._0.Commands;
using LibraryManager.Domain.Models;
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
        private readonly BooksStore booksStore;
        private readonly SelctedBookStore selctedBookStore;
        private readonly ModalNavigationStore modalNavigationStore;

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

        public BooksListingViewModel(BooksStore _booksStore, SelctedBookStore _selctedBookStore,ModalNavigationStore _modalNavigationStore)
        {
            booksStore = _booksStore;
            selctedBookStore = _selctedBookStore;
            modalNavigationStore = _modalNavigationStore;
            _booksListingItemViewModel = new ObservableCollection<BooksListingItemViewModel>();

            booksStore.BookAdded += BooksStore_BookAdded;
            booksStore.BookUpdated += BooksStore_BookUpdated;
        
        }

        private void BooksStore_BookUpdated(Book obj)
        {
            BooksListingItemViewModel bookViewModel = _booksListingItemViewModel.FirstOrDefault(b => b.Book.Id == obj.Id);

            if(bookViewModel!=null)
            {
                bookViewModel.Update(obj);
            }
        }

        protected override void Dispose()
        {
            booksStore.BookUpdated -= BooksStore_BookUpdated;
            booksStore.BookAdded -= BooksStore_BookAdded;
            base.Dispose(); 
        }
        private void BooksStore_BookAdded(Book obj)
        {
            AddBook(obj);
        }

        private void AddBook(Book book)
        {
            BooksListingItemViewModel booksListingItemViewModel = new BooksListingItemViewModel(book, booksStore, modalNavigationStore);
            _booksListingItemViewModel.Add(booksListingItemViewModel);
        }
    }
}
