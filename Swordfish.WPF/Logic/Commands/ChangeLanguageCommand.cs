using Swordfish.Logic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Swordfish.WPF.Logic.Commands
{
    public class ChangeLanguageCommand : CommandLogged
    {
        Language languageToChange;
        SwordFishViewModel swordFishViewModel;

        public ChangeLanguageCommand(Language languageToChange, SwordFishViewModel swordFishViewModel)
        {
            this.languageToChange = languageToChange;
            this.swordFishViewModel = swordFishViewModel;
        }

        public override void Execute(object? parameter)
        {
            if (swordFishViewModel.CurrentLanguage.IsUsLanguage && languageToChange == Language.US)
                return;
            else if (swordFishViewModel.CurrentLanguage.IsGreekLanguage && languageToChange == Language.GR)
                return;

            swordFishViewModel.CurrentLanguage.ReRenderLanguage(languageToChange);


        }
    }
}
