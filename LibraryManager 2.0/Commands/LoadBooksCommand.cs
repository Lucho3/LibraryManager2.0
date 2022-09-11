using LibraryManager_2._0.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Commands
{
    class LoadBooksCommand : AsyncCommandBase
    {
        private readonly BooksStore _booksStore;

        public LoadBooksCommand(BooksStore booksStore)
        {
            _booksStore = booksStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            try
            {
               await _booksStore.Load();
            }
            catch (Exception)
            {
                throw;
            }
           
        }
    }
}
