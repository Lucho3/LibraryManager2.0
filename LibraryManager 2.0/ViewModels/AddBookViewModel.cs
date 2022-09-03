using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.ViewModels
{
    class AddBookViewModel:ViewModelBase
    {
        public BookDetailsFormViewModel BookDetailsFormViewModel { get; }



        public AddBookViewModel()
        {
            BookDetailsFormViewModel = new BookDetailsFormViewModel();
        }
    }
}
