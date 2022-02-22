using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swordfish.WPF.Logic.Commands
{
    public abstract class CommandLogged : ICommand
    {
        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter)=>true;

        public abstract void Execute(object? parameter);
    }
}
