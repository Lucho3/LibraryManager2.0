using LibraryManager_2._0.Models;
using LibraryManager_2._0.Stores;
using LibraryManager_2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Commands
{
    class OpenEditBookCommand:CommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly BooksListingItemViewModel _booksListingItemViewModel;
        private readonly BooksStore _booksStore;

        public OpenEditBookCommand(BooksListingItemViewModel booksListingItemViewModel, BooksStore booksStore, ModalNavigationStore modalNavigationStore)
        {
            _booksListingItemViewModel = booksListingItemViewModel;
            _booksStore = booksStore;
            _modalNavigationStore = modalNavigationStore;
        }



        public override void Execute(object parameter)
        {
            Book book = _booksListingItemViewModel.Book;
            EditBookViewModel editBookViewModel = new EditBookViewModel(book,_booksStore,_modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editBookViewModel;
        }
    }
}
