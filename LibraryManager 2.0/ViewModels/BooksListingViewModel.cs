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
        private readonly SelectedBookStore selectedBookStore;
        private readonly ModalNavigationStore modalNavigationStore;

        public IEnumerable<BooksListingItemViewModel> BooksListingItemViewModels => _booksListingItemViewModel;

        public BooksListingItemViewModel SelectedBookListingItemViewModel
        {
            get 
            {
                return _booksListingItemViewModel.FirstOrDefault(b=>b.Book?.Id==selectedBookStore.SelectedBook?.Id);
            }
            set
            {
                selectedBookStore.SelectedBook = value?.Book;

                
            }
        }

        public BooksListingViewModel(BooksStore _booksStore, SelectedBookStore _selctedBookStore,ModalNavigationStore _modalNavigationStore)
        {
            booksStore = _booksStore;
            selectedBookStore = _selctedBookStore;
            modalNavigationStore = _modalNavigationStore;
            _booksListingItemViewModel = new ObservableCollection<BooksListingItemViewModel>();

            selectedBookStore.SelectedBookChanged += SelectedBookStore_SelectedBookChanged;

            booksStore.BookDeleted += BooksStore_BookDeleted;
            booksStore.BooksLoaded += _booksStore_BooksLoaded;
            booksStore.BookAdded += BooksStore_BookAdded;
            booksStore.BookUpdated += BooksStore_BookUpdated;

            _booksListingItemViewModel.CollectionChanged += _booksListingItemViewModel_CollectionChanged;
        }

        private void _booksListingItemViewModel_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            OnPropertyChanged(nameof(SelectedBookListingItemViewModel));
        }

        private void SelectedBookStore_SelectedBookChanged()
        {
            OnPropertyChanged(nameof(SelectedBookListingItemViewModel));
        }

        private void BooksStore_BookDeleted(Guid id)
        {
            BooksListingItemViewModel book=_booksListingItemViewModel.FirstOrDefault(b => b.Book?.Id == id);
            if(book!=null)
            {
                _booksListingItemViewModel.Remove(book);
            }
           
        }

        private void _booksStore_BooksLoaded()
        {
            _booksListingItemViewModel.Clear();

            foreach (Book book in booksStore.Books)
            {
                AddBook(book);
            }
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
            booksStore.BookDeleted -= BooksStore_BookDeleted;
            booksStore.BooksLoaded -= _booksStore_BooksLoaded;
            booksStore.BookUpdated -= BooksStore_BookUpdated;
            booksStore.BookAdded -= BooksStore_BookAdded;
            selectedBookStore.SelectedBookChanged -= SelectedBookStore_SelectedBookChanged;
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
