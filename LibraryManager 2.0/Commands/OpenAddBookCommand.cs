using LibraryManager_2._0.Stores;
using LibraryManager_2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManager_2._0.Commands
{
    class OpenAddBookCommand : CommandBase
    {
        private readonly BooksStore booksStore;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddBookCommand(BooksStore _booksStore, ModalNavigationStore modalNavigationStore)
        {
            booksStore = _booksStore;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            AddBookViewModel addBookViewModel = new AddBookViewModel(booksStore,_modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = addBookViewModel;
        }
    }
}
