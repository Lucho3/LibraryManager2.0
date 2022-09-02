using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Models
{
    class Book
    {
        public Book(string author, string date, string title, string genre, string language, int nPages, int quantity, int quantityT)
        {
            Author = author;
            Date = date;
            Title = title;
            Genre = genre;
            Language = language;
            NPages = nPages;
            Quantity = quantity;
            QuantityT = quantityT;
        }

        public string Author { get; }
        public string Date { get; }
        public string Title { get; }
        public string Genre { get; }
        public string Language { get; }
        public int NPages { get; }
        public int Quantity { get; }
        public int QuantityT { get; }

        //TODO IMage
    }
}
