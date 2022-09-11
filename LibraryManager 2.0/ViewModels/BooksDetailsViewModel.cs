using LibraryManager.Domain.Models;
using LibraryManager_2._0.Stores;
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
        private readonly SelectedBookStore _selctedBookStore;
        public bool HasSelectedBook => selectedBook != null;
        private Book selectedBook => _selctedBookStore.SelectedBook; 
        public string Author => selectedBook?.Author ?? "Unkonwn";
        public string Date => selectedBook?.Date.ToString() ?? "Unkonwn";
        public string Title => selectedBook?.Title ?? "Unkonwn";
        public string Genre => selectedBook?.Genre ?? "Unkonwn";
        public string Language => selectedBook?.Language ?? "Unkonwn";
        public int NPages => selectedBook?.NPages ?? 0;
        public int Quantity => selectedBook?.Quantity ?? 0;
        public int QuantityT => selectedBook?.QuantityT ?? 0;


        public BooksDetailsViewModel(SelectedBookStore selctedBookStore)
        {

            _selctedBookStore = selctedBookStore;

            _selctedBookStore.SelectedBookChanged += _selctedBookStore_SelectedBookChanged;
        }

        protected override void Dispose()
        {
            _selctedBookStore.SelectedBookChanged -= _selctedBookStore_SelectedBookChanged;
            base.Dispose();
        }
        private void _selctedBookStore_SelectedBookChanged()
        {

            OnPropertyChanged(nameof(HasSelectedBook));
            OnPropertyChanged(nameof(Author));
            OnPropertyChanged(nameof(Date));
            OnPropertyChanged(nameof(Title));
            OnPropertyChanged(nameof(Genre));
            OnPropertyChanged(nameof(Language));
            OnPropertyChanged(nameof(NPages));
            OnPropertyChanged(nameof(Quantity));
            OnPropertyChanged(nameof(QuantityT));
        }
    }
}
