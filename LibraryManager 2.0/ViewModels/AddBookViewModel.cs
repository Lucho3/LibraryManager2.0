using LibraryManager_2._0.Commands;
using LibraryManager_2._0.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManager_2._0.ViewModels
{
    class AddBookViewModel:ViewModelBase
    {
        public BookDetailsFormViewModel BookDetailsFormViewModel { get; }

        public AddBookViewModel(BooksStore booksStore, ModalNavigationStore modalNavigationStore)
        {
            ICommand submitCommand=new AddBookCommand(this,booksStore,modalNavigationStore);
            ICommand cancelCommand = new CloseModalCommand(modalNavigationStore);
            BookDetailsFormViewModel = new BookDetailsFormViewModel(submitCommand, cancelCommand);
        }
    }
}
