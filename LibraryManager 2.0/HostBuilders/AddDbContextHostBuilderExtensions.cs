using LibraryManager.EntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.HostBuilders
{
    public static class AddDbContextHostBuilderExtensions
    {
        public static IHostBuilder AddDbContext(this IHostBuilder hostBuilder)
        {
            hostBuilder.ConfigureServices((context, services) =>
             {
                 string _connectionString = context.Configuration.GetConnectionString("sqlite");

                 services.AddSingleton<DbContextOptions>(new DbContextOptionsBuilder().UseSqlite(_connectionString).Options);
                 services.AddSingleton<BooksDbContextFactory>();
             });
              
            return hostBuilder;
        }
    }
}
