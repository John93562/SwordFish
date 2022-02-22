
using Swordfish.WPF.Logic.Commands;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Swordfish.Login.Commands
{
    public abstract class AsyncCommandBase : CommandLogged
    {
        private bool isExecuting;
      
        public bool IsExecuting
        {
            get => isExecuting;
            set
            {
                isExecuting = value;
                OnCanExecutionChanged();
            }
        }
        public event EventHandler? CanExecuteChanged;
        protected void OnCanExecutionChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        public  bool CanExecute(object parameter)
        {
            return !IsExecuting;
        }


        private void OnFaultCompletion(Task task)
        {
            MessageBox.Show("Error : " + task.Exception.Message);
            
        }

        public async Task ExecuteAsync(object parameter)
        {
            await Task.Run(() => ExecuteMethod(parameter));
        }
        public abstract Task ExecuteMethod(object parameter);

        public override void Execute(object? parameter)
        {
            IsExecuting = true;
            ExecuteAsync(parameter).ContinueWith(OnFaultCompletion, TaskContinuationOptions.OnlyOnFaulted);
            IsExecuting = false;
        }
    }
}
