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
    class EditBookViewModel:ViewModelBase
    {
        public Guid BookId { get; }
        public BookDetailsFormViewModel BookDetailsFormViewModel { get; }

        public EditBookViewModel(Book book, BooksStore _booksStore, ModalNavigationStore modalNavigationStore)
        {
            BookId = book.Id;
            ICommand editCommand = new EditBookCommand(this,_booksStore, modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            BookDetailsFormViewModel = new BookDetailsFormViewModel(editCommand, cancelCommand)
            {
                Author = book.Author,
                Title = book.Title,
                Date = book.Date,
                Quantity = book.Quantity,
                QuantityT = book.QuantityT,
                Language = book.Language,
                NPages = book.NPages,
                Genre = book.Genre
            };
        }
    }
}
