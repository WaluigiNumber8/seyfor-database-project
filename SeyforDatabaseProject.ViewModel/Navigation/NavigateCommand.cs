using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Navigation
{
    /// <summary>
    /// Command to navigate using the provided navigation service.
    /// </summary>
    public class NavigateCommand : CommandBase
    {
        private readonly INavigationService _service;

        public NavigateCommand(INavigationService service)
        {
            _service = service;
        }

        public override void Execute(object? parameter) => _service.Navigate();
    }
}