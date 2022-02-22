using Swordfish.Logic.Models;
using Swordfish.WPF.Logic;
using Swordfish.WPF.Logic.Commands;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Swordfish.Logic
{
    public class SwordFishViewModel : ViewModelBase
    {
        public CurrentLanguage CurrentLanguage { get; set; }
        private WindowState windowState = WindowState.Normal;
        public WindowState WindowState
        {
            get
            {
                return windowState;
            }
            set
            {
                windowState = value;
                OnPropertyChanged(nameof(WindowState));
            }
        }
        private bool isFolderEncryptVisible = true;
        public bool IsFolderEncryptVisible
        {
            get
            {
                return isFolderEncryptVisible;
            }
            set
            {
                isFolderEncryptVisible = value;
                OnPropertyChanged(nameof(IsFolderEncryptVisible));
                OnPropertyChanged(nameof(IsFileEncryptVisible));
            }
        }
        public bool IsFileEncryptVisible => !IsFolderEncryptVisible;

        private bool isInfoVisible;
        public bool IsInfoVisible
        {
            get
            {
                return isInfoVisible;
            }
            set
            {
                isInfoVisible= value;
                OnPropertyChanged(nameof(IsInfoVisible));
            }
        }

        public ICommand ToggleFileAndFolderVisibilityCommand { get; set; }
        public ICommand ToggleInfoVisibilityCommand { get; set; }
        public ICommand ShutdownApplicationCommand { get; set; }
        public ICommand MinimizeApplicationCommand { get; set; }
        public ICommand ChangeLanguageToEnglishCommand { get; set; }
        public ICommand ChangeLanguageToGreekCommand { get; set; }
        public ICommand NavigateToBrowserCommand { get; set; }
        public ICommand EncryptFolderCommand { get; set; }
        public ICommand EncryptFileCommand { get; set; }
        public ICommand DecryptCommand { get; set; }
        public SwordFishViewModel()
        {

            CurrentLanguage = new CurrentLanguage(Language.US);

            NavigateToBrowserCommand = new NavigateToBrowserCommand();
            ShutdownApplicationCommand = new ShutdownApplicationCommand();
            MinimizeApplicationCommand = new MinimizeApplicationCommand(this);

            ToggleInfoVisibilityCommand = new ToggleInfoVisibilityCommand(this);
            ToggleFileAndFolderVisibilityCommand = new ToggleFileAndFolderVisibilityCommand(this);

            ChangeLanguageToEnglishCommand = new ChangeLanguageCommand(Language.US,this);
            ChangeLanguageToGreekCommand = new ChangeLanguageCommand(Language.GR,this);
        }

    }
}