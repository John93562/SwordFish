using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Swordfish.WPF.Logic.Commands
{
    public class ShutdownApplicationCommand : CommandLogged
    {
        public override void Execute(object? parameter)
        {
            Application.Current.Shutdown();
        }
    }

}
