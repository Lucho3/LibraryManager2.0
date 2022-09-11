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
    class AddBookCommand : AsyncCommandBase
    {
        private readonly AddBookViewModel addBookViewModel;
        private readonly BooksStore booksStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public AddBookCommand(AddBookViewModel addBookViewModel, BooksStore _booksStore, ModalNavigationStore modalNavigationStore)
        {
            this.addBookViewModel = addBookViewModel;
            this.booksStore = _booksStore;
            _modalNavigationStore = modalNavigationStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            
            BookDetailsFormViewModel formViewModel = addBookViewModel.BookDetailsFormViewModel;

            formViewModel.ErrorMessage = null;
            formViewModel.IsSubmitting = true;
            
            Book book = new Book(Guid.NewGuid(),formViewModel.Author,formViewModel.Date,formViewModel.Title,formViewModel.Genre,formViewModel.Language,formViewModel.NPages,formViewModel.Quantity,formViewModel.QuantityT);
            try
            {
                await booksStore.Add(book);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {
                formViewModel.ErrorMessage = "Failed to add the book. Please try again later!";
            }
            finally
            {
                formViewModel.IsSubmitting = false;
            }

           
        }
    }
}
