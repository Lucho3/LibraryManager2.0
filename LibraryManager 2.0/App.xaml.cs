using LibraryManager_2._0.Stores;
using LibraryManager_2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace LibraryManager_2._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly ModalNavigationStore _modalNavigationStore;
        private readonly BooksStore _booksStore;
        private readonly SelctedBookStore _selctedBookStore;
        protected override void OnStartup(StartupEventArgs e)
        {
            BooksViewModel booksViewModel = new BooksViewModel(_selctedBookStore,_modalNavigationStore,_booksStore);
            MainWindow = new MainWindow()
            {

                DataContext=new MainViewModel(_modalNavigationStore, booksViewModel)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        public App()
        {
            _booksStore = new BooksStore();
            _selctedBookStore = new SelctedBookStore(_booksStore);
            _modalNavigationStore = new ModalNavigationStore();
        }
    }
}
