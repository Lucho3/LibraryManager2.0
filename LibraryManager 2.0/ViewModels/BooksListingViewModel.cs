using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.ViewModels
{
    class BooksListingViewModel:ViewModelBase
    {
        private readonly ObservableCollection<BooksListingItemViewModel> _booksListingItemViewModel;
        public IEnumerable<BooksListingItemViewModel> BooksListingItemViewModels => _booksListingItemViewModel;

        public BooksListingViewModel()
        {
            _booksListingItemViewModel = new ObservableCollection<BooksListingItemViewModel>();

            _booksListingItemViewModel.Add(new BooksListingItemViewModel("Kniga1"));
            _booksListingItemViewModel.Add(new BooksListingItemViewModel("Kniga2"));
            _booksListingItemViewModel.Add(new BooksListingItemViewModel("Kniga3"));
        }
    }
}
