using System.Windows.Input;

namespace SeyforDatabaseProject.ViewModel
{
    public class AddEntryCommand : ICommand
    {
        public bool CanExecute(object? parameter)
        {
            return false;
        }

        public void Execute(object? parameter)
        {
        }

        public event EventHandler? CanExecuteChanged;
    }
}