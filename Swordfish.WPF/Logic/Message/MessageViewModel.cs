
using Swordfish.Logic;
using Swordfish.Logic.Models;
using Swordfish.Logic.StaticResources;
using System.Windows.Media;
using System.Windows.Threading;

namespace Swordfish.Logic.Message
{

    public class MessageViewModel : ViewModelBase
    {

        public string Id { get; set; }

        private string message;
        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged(nameof(Message));
            }
        }

        private Brush color;

        public MessageViewModel(string message, MessageColor messageColor)
        {
            Message = message;
            Message = message;

            SolidColorBrush solid = new SolidColorBrush();
            Color color;
            switch (messageColor)
            {
                case MessageColor.Success:
                    color = (Color)ColorConverter.ConvertFromString("#435F43");

                    break;
                case MessageColor.Warning:
                    color = (Color)ColorConverter.ConvertFromString("#B1734E");

                    break;
                case MessageColor.Fail:
                    color = (Color)ColorConverter.ConvertFromString("#491F1F");

                    break;
                default:
                    break;
            }
            SolidColorBrush bi = new SolidColorBrush(color);

            bi.Freeze();

            Dispatcher.CurrentDispatcher.Invoke(() => Color = bi);

        }

        public Brush Color
        {
            get => color;
            set
            {
                color = value;
                OnPropertyChanged(nameof(Color));
            }
        }




    }
}
