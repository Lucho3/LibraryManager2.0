using LibraryManager_2._0.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Commands
{
    class EditBookCommand : AsyncCommandBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        public EditBookCommand(ModalNavigationStore modalNavigationStore)
        {
            _modalNavigationStore = modalNavigationStore;
        }
        public override async Task ExecuteAsync(object parameter)
        {
            //edit book to db
            _modalNavigationStore.Close();
        }
    }
}
