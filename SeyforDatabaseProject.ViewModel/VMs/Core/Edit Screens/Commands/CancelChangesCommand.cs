namespace SeyforDatabaseProject.ViewModel.Core
{
    public class CancelChangesCommand : CommandBase
    {
        private readonly Action _navigateToListing;

        public CancelChangesCommand(Action navigateToListing)
        {
            _navigateToListing = navigateToListing;
        }

        public override void Execute(object? parameter)
        {
            _navigateToListing.Invoke();
        }
    }
}