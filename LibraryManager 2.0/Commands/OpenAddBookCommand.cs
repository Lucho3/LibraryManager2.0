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
        private readonly ModalNavigationStore _modalNavigationStore;

        public OpenAddBookCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }

        public override void Execute(object parameter)
        {
            AddBookViewModel addBookViewModel = new AddBookViewModel();
            _modalNavigationStore.CurrentViewModel = addBookViewModel;
        }
    }
}
