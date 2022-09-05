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
        private readonly Book _book;
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenEditBookCommand(Book book,ModalNavigationStore modalNavigationStore)
        {
            _book = book;
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            EditBookViewModel editBookViewModel = new EditBookViewModel(_book,_modalNavigationStore);
            _modalNavigationStore.CurrentViewModel = editBookViewModel;
        }
    }
}
