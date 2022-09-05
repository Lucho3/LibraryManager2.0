using LibraryManager_2._0.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Commands
{
    class AddBookCommand : AsyncCommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public AddBookCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            //add book to db
            _modalNavigationStore.Close();
        }
    }
}
