using LibraryManager_2._0.Stores;
using LibraryManager_2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Commands
{
    class LoadBooksCommand : AsyncCommandBase
    {
        private readonly BooksViewModel _booksViewModel;
        private readonly BooksStore _booksStore;

        public LoadBooksCommand(BooksViewModel booksViewModel, BooksStore booksStore)
        {
            _booksViewModel = booksViewModel;
            _booksStore = booksStore;
        }

        public override async Task ExecuteAsync(object parameter)
        {
            _booksViewModel.IsLoading = true;
            try
            {
               await _booksStore.Load();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _booksViewModel.IsLoading = false;
            }
        }
    }
}
