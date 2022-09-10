using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Models
{
    public class Book
    {
        public Book(Guid id,string author, DateTime date, string title, string genre, string language, int nPages, int quantity, int quantityT)
        {
            Id = id;
            Author = author;
            Date = date;
            Title = title;
            Genre = genre;
            Language = language;
            NPages = nPages;
            Quantity = quantity;
            QuantityT = quantityT;
        }

        public Guid Id { get; }
        public string Author { get; }
        public DateTime Date { get; }
        public string Title { get; }
        public string Genre { get; }
        public string Language { get; }
        public int NPages { get; }
        public int Quantity { get; }
        public int QuantityT { get; }

        //TODO IMage
    }
}
