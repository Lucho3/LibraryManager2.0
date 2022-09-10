using LibraryManager.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManager.Domain.Commands
{
    public interface IUpdateBookCommand
    {
        Task Execute(Book book);
    }
}
