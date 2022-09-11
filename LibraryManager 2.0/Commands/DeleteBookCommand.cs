using LibraryManager.Domain.Models;
using LibraryManager_2._0.Stores;
using LibraryManager_2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Commands
{
    class DeleteBookCommand : AsyncCommandBase
    {
        private readonly BooksListingItemViewModel _booksListingItemViewModel;
        private readonly BooksStore _booksStore;

        public DeleteBookCommand(BooksListingItemViewModel booksListingItemViewModel, BooksStore booksStore)
        {
            _booksListingItemViewModel = booksListingItemViewModel;
            _booksStore = booksStore;
        }


        public override async Task ExecuteAsync(object parameter)
        {
            Book book = _booksListingItemViewModel.Book;

            _booksListingItemViewModel.IsDeleting = true;
            _booksListingItemViewModel.ErrorMessage = null;
            try
            {
                await _booksStore.Delete(book.Id);
            }
            catch (Exception)
            {

                _booksListingItemViewModel.ErrorMessage = "Failed to delete the book. Please try again later!";
            }
            finally
            {
                _booksListingItemViewModel.IsDeleting = false;
            }
            
        }
    }
}
