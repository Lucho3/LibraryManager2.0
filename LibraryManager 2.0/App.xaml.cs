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
        private readonly SelctedBookStore _selctedBookStore;
        protected override void OnStartup(StartupEventArgs e)
        {
            MainWindow = new MainWindow()
            {
                DataContext=new BooksViewModel(_selctedBookStore)
            };
            MainWindow.Show();
            base.OnStartup(e);
        }

        public App()
        {
            _selctedBookStore = new SelctedBookStore();
        }
    }
}
