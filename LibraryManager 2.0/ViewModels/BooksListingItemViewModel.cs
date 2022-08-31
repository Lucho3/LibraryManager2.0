using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace LibraryManager_2._0.ViewModels
{
    class BooksListingItemViewModel : ViewModelBase
    {
        public string Author { get; }

        public ICommand EditCommand { get; }
        public ICommand DeleteCommand { get; }

        public BooksListingItemViewModel(string author)
        {
            Author = author;
        }
    }
}