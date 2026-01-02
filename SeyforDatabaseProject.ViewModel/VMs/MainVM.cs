using System.Windows.Input;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Equipment;
using SeyforDatabaseProject.ViewModel.Navigation;
using SeyforDatabaseProject.ViewModel.Rooms;

namespace SeyforDatabaseProject.ViewModel
{
    /// <summary>
    /// The view model for the main application window.
    /// </summary>
    public class MainVM : ViewModelBase
    {
        #region Commands

        public ICommand NavigateEquipmentCommand { get; }
        public ICommand NavigateRoomsCommand { get; }

        #endregion
        
        private readonly NavigationStore _navigationStore;
        
        public ViewModelBase CurrentVM { get => _navigationStore.CurrentVM; }

        public MainVM(NavigationStore navigationStore, NavigationService<ScreenEquipmentOperationsVM> navigateToEquipment, NavigationService<ScreenRoomOperationsVM> navigateToRooms)
        {
            _navigationStore = navigationStore;
            _navigationStore.OnViewModelChanged += WhenChangeViewModel;

            NavigateEquipmentCommand = new NavigateCommand(navigateToEquipment);
            NavigateRoomsCommand = new NavigateCommand(navigateToRooms);
        }

        private void WhenChangeViewModel() => OnPropertyChanged(nameof(CurrentVM));
    }
}