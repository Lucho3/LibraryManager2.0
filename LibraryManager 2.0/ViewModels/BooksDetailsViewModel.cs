using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace LibraryManager_2._0.ViewModels
{
    class BooksDetailsViewModel : ViewModelBase
    {
        public string Author { get; }
        public string Date { get; }
        public string Title { get; }
        public string Genre { get; }
        public string Language { get; }
        public int NPages { get; }
        public int Quantity { get; }
        public int QuantityT { get; }

        public string imageSource;

        public BooksDetailsViewModel()
        {
            Author = "aaaa";
            Date = DateTime.Now.ToString("dd/MM/yyyy"); ;
            Title = "dddd";
            Genre = "dsdfsf";
            Language = "blabla";
            NPages = 12;
            Quantity = 13;
            QuantityT = 13;
            imageSource = "C:\\Users\\lucho\\OneDrive\\Desktop\\LibraryManager\\LibraryManager 2.0\\Components\\logo.png";
        }
    }
}
