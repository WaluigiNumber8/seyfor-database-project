using System;
using System.Windows.Input;

namespace SeyforDatabaseProject.ViewModel.Core
{
    /// <summary>
    /// A base class for command implementations.
    /// </summary>
    public abstract class CommandBase : ICommand
    {
        public event EventHandler? CanExecuteChanged;
        
        public virtual bool CanExecute(object? parameter) => true;

        public abstract void Execute(object? parameter);
    
        protected void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }
    }
}