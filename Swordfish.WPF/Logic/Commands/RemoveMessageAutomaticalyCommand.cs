
using Swordfish.Logic.Message;
using Swordfish.Logic.Models;
using System.Threading.Tasks;

namespace Swordfish.Login.Commands
{

    public class RemoveMessageAutomaticalyCommand : AsyncCommandBase
    {
        private readonly MessageViewModelShow ShowCustomerViewModel;

        public RemoveMessageAutomaticalyCommand(MessageViewModelShow showCustomerViewModel)
        {
            ShowCustomerViewModel = showCustomerViewModel;
        }

        public override async Task ExecuteMethod(object parameter)
        {
            if (parameter is RemoveMessageWithId)
            {
                RemoveMessageWithId message = parameter as RemoveMessageWithId;
                await Task.Run(() => AwaitAndDeleteMessage(message));
            }

        }

        private async Task AwaitAndDeleteMessage(RemoveMessageWithId message)
        {

            await Task.Delay(message.MilisecondsToAutoDelete);
            if (ShowCustomerViewModel.MessageViewModel is not null && ShowCustomerViewModel.MessageViewModel.Id == message.Id)
            {
                ShowCustomerViewModel.MessageViewModel = null;
            }
        }
    }
}
