
using Swordfish.Logic.Message;
using System;
using System.Windows.Input;

namespace Swordfish.Login.Commands
{

    public class RemoveMessageCommand : ICommand
    {
        private readonly MessageViewModelShow ShowCustomerViewModel;

        public RemoveMessageCommand(MessageViewModelShow showCustomerViewModel) 
        {
            ShowCustomerViewModel = showCustomerViewModel;
        }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ShowCustomerViewModel.MessageViewModel = null;
        }
    }
}
