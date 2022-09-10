using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.EntityFramework
{
    public class BooksDbContextFactory
    {
        private readonly DbContextOptions _options;

        public BooksDbContextFactory(DbContextOptions options)
        {
            this._options = options;
        }

        public BooksDbContext Create()
        {
            return new BooksDbContext(_options);
        }
    }
}
