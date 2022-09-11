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
    class EditBookCommand : AsyncCommandBase
    {
        private readonly EditBookViewModel _editBookViewModel;
        private readonly BooksStore _booksStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public EditBookCommand(EditBookViewModel editBookViewModel, BooksStore booksStore,ModalNavigationStore modalNavigationStore)
        {
            this._editBookViewModel = editBookViewModel;
            this._booksStore = booksStore;
            _modalNavigationStore = modalNavigationStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            BookDetailsFormViewModel formViewModel = _editBookViewModel.BookDetailsFormViewModel;

            formViewModel.IsSubmitting = true;
            Book book = new Book(_editBookViewModel.BookId, formViewModel.Author, formViewModel.Date, formViewModel.Title, formViewModel.Genre, formViewModel.Language, formViewModel.NPages, formViewModel.Quantity, formViewModel.QuantityT);
            try
            {
                await _booksStore.Update(book);
                _modalNavigationStore.Close();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                formViewModel.IsSubmitting = false;
            }
        }
    }
}
