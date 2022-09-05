using LibraryManager_2._0.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Stores
{
    class ModalNavigationStore
    {
        private ViewModelBase _currentViewModel;

        public ViewModelBase CurrentViewModel
        {
            get 
            { 
                return _currentViewModel; 
            }
            set 
            {
                _currentViewModel = value;
                //Dispose?
                CurrentViewModelChanged?.Invoke();
            }
        }

        internal void Close()
        {
            CurrentViewModel = null;
        }

        public bool IsOpen => CurrentViewModel != null;

        public event Action CurrentViewModelChanged;
    }
}
