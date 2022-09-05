using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager_2._0.Commands
{
    abstract class AsyncCommandBase : CommandBase
    {
        public override async void Execute(object parameter)
        {
            try
            {
                await ExecuteAsync(parameter);
            }
            catch (Exception)
            {

            }
            
        }

        public abstract Task ExecuteAsync(object parameter);
    }
}
