using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Navigation
{
    /// <summary>
    /// A service for handling navigation between views.
    /// </summary>
    public class NavigationService<TVM> : INavigationService where TVM : ViewModelBase
    {
        private readonly NavigationStore _navigationStore;
        private readonly Func<TVM> _createViewModel;
        
        public NavigationService(NavigationStore navigationStore, Func<TVM> createViewModel)
        {
            _navigationStore = navigationStore;
            _createViewModel = createViewModel;
        }
        
        public void Navigate() => _navigationStore.CurrentVM = _createViewModel();
    }
}