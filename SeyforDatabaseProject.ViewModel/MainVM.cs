using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel
{
    /// <summary>
    /// The view model for the main application window.
    /// </summary>
    public class MainVM : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        
        public ViewModelBase CurrentVM { get => _navigationStore.CurrentVM; }

        public MainVM(NavigationStore navigationStore)
        {
            _navigationStore = navigationStore;
            _navigationStore.OnViewModelChanged += WhenChangeViewModel;
        }

        private void WhenChangeViewModel() => OnPropertyChanged(nameof(CurrentVM));
    }
}