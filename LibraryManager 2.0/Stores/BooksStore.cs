using LibraryManager_2._0.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Stores
{
    class BooksStore
    {
        public event Action<Book> BookAdded;
        public event Action<Book> BookUpdated;

        public async Task Add(Book book)
        {
            BookAdded?.Invoke(book);
        }

        public async Task Update(Book book)
        {
            BookUpdated?.Invoke(book);
        }


    }
}
