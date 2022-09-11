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
    class BooksViewModel : ViewModelBase
    {
        public BooksListingViewModel BooksListingViewModel { get; }

        public BooksDetailsViewModel BooksDetailsViewModel { get; }

        private bool _isLoading;
        public bool IsLoading
        {
            get
            { 
                return _isLoading; 
            }
            set 
            { 
                _isLoading = value;
                OnPropertyChanged(nameof(IsLoading));
            }
        }

        private string _errorMessage;
        public string ErrorMessage
        {
            get
            {
                return _errorMessage;
            }
            set
            {
                _errorMessage = value;
                OnPropertyChanged(nameof(ErrorMessage));
                OnPropertyChanged(nameof(HasErrorMessage));
            }
        }

        public bool HasErrorMessage => !string.IsNullOrEmpty(ErrorMessage);
        public ICommand AddBooksCommand { get; }

        public ICommand LoadBooksCommand { get; }

        public BooksViewModel(SelctedBookStore _selctedBookStore, ModalNavigationStore modalNavigationStore, BooksStore booksStore)
        {
            BooksDetailsViewModel = new BooksDetailsViewModel(_selctedBookStore);
            BooksListingViewModel = new BooksListingViewModel(booksStore, _selctedBookStore,modalNavigationStore);

            LoadBooksCommand = new LoadBooksCommand(this,booksStore);
            AddBooksCommand = new OpenAddBookCommand(booksStore,modalNavigationStore);
        }


        public static BooksViewModel LoadViewModel(SelctedBookStore _selctedBookStore, ModalNavigationStore modalNavigationStore, BooksStore booksStore)
        {
            BooksViewModel viewModel = new BooksViewModel(_selctedBookStore, modalNavigationStore, booksStore);

            viewModel.LoadBooksCommand.Execute(null);

            return viewModel;
        }

    }
}
