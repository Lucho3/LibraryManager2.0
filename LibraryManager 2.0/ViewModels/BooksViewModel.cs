﻿using LibraryManager_2._0.Commands;
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
        public ICommand AddBooksCommand { get; }

        public BooksViewModel(SelctedBookStore _selctedBookStore, ModalNavigationStore modalNavigationStore, BooksStore booksStore)
        {
            BooksDetailsViewModel = new BooksDetailsViewModel(_selctedBookStore);
            BooksListingViewModel = new BooksListingViewModel(booksStore, _selctedBookStore,modalNavigationStore);
            AddBooksCommand = new OpenAddBookCommand(booksStore,modalNavigationStore);
        }


    }
}
