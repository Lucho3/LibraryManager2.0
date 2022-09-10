using LibraryManager.Domain.Commands;
using LibraryManager.Domain.Queries;
using LibraryManager_2._0.Stores;
using LibraryManager_2._0.ViewModels;
using LibraryManager.EntityFramework.Commands;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using LibraryManager.EntityFramework.Queries;
using LibraryManager.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace LibraryManager_2._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IGetAllBooksQuery _getAllBooksQuery;
        private readonly ICreateBookCommand _createBookCommand;
        private readonly IUpdateBookCommand _updateBookCommand;
        private readonly IDeleteBookCommand _deleteBookCommand;

        private readonly BooksDbContextFactory _booksDbContextFactory;
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
            string _connectionString = "Data Source=Books.db";
            _booksDbContextFactory = new BooksDbContextFactory(
                 new DbContextOptionsBuilder().UseSqlite(_connectionString).Options);

            using (BooksDbContext context = _booksDbContextFactory.Create())
            {
                context.Database.Migrate();
            }

              
            _getAllBooksQuery = new GetAllBooksQuery(_booksDbContextFactory);
            _deleteBookCommand = new DeleteBookCommand(_booksDbContextFactory);      
            _createBookCommand = new CreateBookCommand(_booksDbContextFactory);
            _updateBookCommand = new UpdateBookCommand(_booksDbContextFactory);

            _booksStore = new BooksStore(_getAllBooksQuery, _createBookCommand, _updateBookCommand, _deleteBookCommand);
            _selctedBookStore = new SelctedBookStore(_booksStore);
            _modalNavigationStore = new ModalNavigationStore();
        }
    }
}
