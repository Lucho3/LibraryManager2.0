using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.EntityFramework
{
    public class BooksDesignTimeDbContextFactory:IDesignTimeDbContextFactory<BooksDbContext>
    {

        public BooksDbContext CreateDbContext(string[] args=null)
        {
            return new BooksDbContext(new DbContextOptionsBuilder().UseSqlite("Data Source=Books.db").Options);
        }
    }
}
