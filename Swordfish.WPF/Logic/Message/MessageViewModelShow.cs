
using Swordfish.Logic;
using Swordfish.Logic.Models;
using Swordfish.Login.Commands;
using System;
using System.Windows.Input;

namespace Swordfish.Logic.Message
{

    public class MessageViewModelShow : ViewModelBase
    {
        public bool HasPersistentMessage => PersistenseMessageViewModel is not null;

        public bool HasMessage => MessageViewModel is not null;

        public ICommand RemoveMessageCommand { get; set; }

        private ICommand RemoveMessageAutomaticalyCommand { get; set; }

        private PersistenseMessageViewModel persistenseMessageViewModel;
        public PersistenseMessageViewModel PersistenseMessageViewModel
        {
            get => persistenseMessageViewModel;
            set
            {
                persistenseMessageViewModel = value;
                OnPropertyChanged(nameof(HasPersistentMessage));
                OnPropertyChanged(nameof(PersistenseMessageViewModel));
            }
        }

        private MessageViewModel messageViewModel;

        internal void ForceClosePersistenseMessage()
        {
            PersistenseMessageViewModel = null;
        }

        public MessageViewModel MessageViewModel
        {
            get => messageViewModel;
            set
            {
                messageViewModel = value;
                OnPropertyChanged(nameof(MessageViewModel));
                OnPropertyChanged(nameof(HasMessage));
            }
        }
        public MessageViewModelShow()
        {
            RemoveMessageCommand = new RemoveMessageCommand(this);
            RemoveMessageAutomaticalyCommand = new RemoveMessageAutomaticalyCommand(this);

        }
        public void ShowMessage(MessageViewModel messageViewModel, float seconds = 4)
        {
            MessageViewModel = null;

            float floatMiliseconds = seconds * 1000;
            int miliseconds = (int)floatMiliseconds;
            string Id = Guid.NewGuid().ToString();
            messageViewModel.Id = Id;
            MessageViewModel = messageViewModel;
            RemoveMessageWithId removeMessageWithId = new RemoveMessageWithId(Id, miliseconds);
            RemoveMessageAutomaticalyCommand?.Execute(removeMessageWithId);

        }
        public void ShowPersistenseMessage(PersistenseMessageViewModel persistenseMessageViewModel)
        {
            PersistenseMessageViewModel = persistenseMessageViewModel;
        }

        public void PersistenseMessageCompletion(MessageViewModel messageViewModel, float seconds = 4)
        {
            PersistenseMessageViewModel = null;
            if (messageViewModel is not null)
            {
                ShowMessage(messageViewModel, seconds);
            }
        }
    }
}
