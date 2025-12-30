using System;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Navigation
{
    /// <summary>
    /// Stores navigation state for the application.
    /// </summary>
    public class NavigationStore
    {
        public event Action OnViewModelChanged;

        private ViewModelBase? _currentVM;

        public ViewModelBase? CurrentVM
        {
            get => _currentVM;
            set
            {
                _currentVM?.Dispose();
                _currentVM = value;
                OnViewModelChanged?.Invoke();
            }
        }
    }
}