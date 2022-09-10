using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.EntityFramework.DTOs
{
    public class BookDTO
    {
        public Guid Id { get; set; }
        public string Author { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public string Language { get; set; }
        public int NPages { get; set; }
        public int Quantity { get; set; }
        public int QuantityT { get; set; }
    }
}
