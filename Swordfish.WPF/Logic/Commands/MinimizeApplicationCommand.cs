using Swordfish.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swordfish.WPF.Logic.Commands
{
    public class MinimizeApplicationCommand : CommandLogged
    {
        SwordFishViewModel swordFishViewModel;

        public MinimizeApplicationCommand(SwordFishViewModel swordFishViewModel)
        {
            this.swordFishViewModel = swordFishViewModel;
        }

        public override void Execute(object? parameter)
        {
            swordFishViewModel.WindowState = System.Windows.WindowState.Minimized;
        }
    }
}
