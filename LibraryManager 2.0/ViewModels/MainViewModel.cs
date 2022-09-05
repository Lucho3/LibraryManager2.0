using LibraryManager_2._0.Stores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.ViewModels
{
    class MainViewModel:ViewModelBase
    {
        private readonly ModalNavigationStore _modalNavigationStore;

        public ViewModelBase CurrentModalViewModel => _modalNavigationStore.CurrentViewModel;

        public bool IsModalOpen => _modalNavigationStore.IsOpen;

        public BooksViewModel BooksViewModel { get; }
        public MainViewModel(ModalNavigationStore modalNavigationStore, BooksViewModel booksViewModel)
        {
            _modalNavigationStore = modalNavigationStore;
            BooksViewModel = booksViewModel;

            _modalNavigationStore.CurrentViewModelChanged += ModalNavigationStore_CurrentViewModelChanged;
        }

        protected override void Dispose()
        {
            _modalNavigationStore.CurrentViewModelChanged -= ModalNavigationStore_CurrentViewModelChanged;
            base.Dispose();
        }

        private void ModalNavigationStore_CurrentViewModelChanged()
        {
            OnPropertyChanged(nameof(CurrentModalViewModel));
            OnPropertyChanged(nameof(IsModalOpen));
        }
    }
}
