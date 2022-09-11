using LibraryManager.Domain.Commands;
using LibraryManager.Domain.Queries;
using LibraryManager_2._0.Stores;
using LibraryManager_2._0.ViewModels;
using LibraryManager_2._0.HostBuilders;
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
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;


namespace LibraryManager_2._0
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private readonly IHost _host;
        protected override void OnStartup(StartupEventArgs e)
        {
            _host.Start();
            BooksDbContextFactory factory = _host.Services.GetRequiredService<BooksDbContextFactory>();
            using (BooksDbContext context = factory.Create())
            {
                context.Database.Migrate();
            }

            MainWindow = _host.Services.GetRequiredService<MainWindow>();
            MainWindow.Show();
            base.OnStartup(e);
        }

        public App()
        {
           
        _host = Host.CreateDefaultBuilder()
           .AddDbContext()
           .ConfigureServices((context, services) =>
           {  
                services.AddSingleton<IGetAllBooksQuery, GetAllBooksQuery>();
                services.AddSingleton<IDeleteBookCommand, DeleteBookCommand>();
                services.AddSingleton<ICreateBookCommand, CreateBookCommand>();
                services.AddSingleton<IUpdateBookCommand, UpdateBookCommand>();

                services.AddSingleton<ModalNavigationStore>();
                services.AddSingleton<BooksStore>();
                services.AddSingleton<SelectedBookStore>();

                services.AddSingleton<MainViewModel>();

                services.AddTransient<BooksViewModel>(CreateBooksViewModel);

                services.AddSingleton<MainWindow>((services)=>new MainWindow()
                { 
                    DataContext=services.GetRequiredService<MainViewModel>()
                });

            }).Build();

        }

        private BooksViewModel CreateBooksViewModel(IServiceProvider services)
        {
            return BooksViewModel.LoadViewModel(
                services.GetRequiredService<SelectedBookStore>(),
                services.GetRequiredService<ModalNavigationStore>(),
                services.GetRequiredService<BooksStore>());
                
        }

        protected override void OnExit(ExitEventArgs e)
        {
            _host.StartAsync();
            _host.Dispose();
            base.OnExit(e); 
        }
    }
}
