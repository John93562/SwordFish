using Swordfish.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Swordfish.WPF.Logic.Commands
{

    public class ToggleInfoVisibilityCommand : CommandLogged
    {
        SwordFishViewModel swordFishViewModel;

        public ToggleInfoVisibilityCommand(SwordFishViewModel swordFishViewModel)
        {
            this.swordFishViewModel = swordFishViewModel;
        }

        public override void Execute(object? parameter)
        {
            swordFishViewModel.IsInfoVisible = !swordFishViewModel.IsInfoVisible;
        }
    }
    public class ToggleFileAndFolderVisibilityCommand : CommandLogged
    {
        SwordFishViewModel swordFishViewModel;

        public ToggleFileAndFolderVisibilityCommand(SwordFishViewModel swordFishViewModel)
        {
            this.swordFishViewModel = swordFishViewModel;
        }

        public override void Execute(object? parameter)
        {
            swordFishViewModel.IsFolderEncryptVisible = !swordFishViewModel.IsFolderEncryptVisible;
        }
    }
}
