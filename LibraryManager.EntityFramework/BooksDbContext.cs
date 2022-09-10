using LibraryManager.EntityFramework.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.EntityFramework
{
    public class BooksDbContext:DbContext
    {
        public BooksDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<BookDTO> Books { get; set; }
    }
}
