using System.Windows.Input;
using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class EquipmentEditVM : ViewModelBase
    {
        #region Properties

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        
        #endregion
        
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EquipmentEditVM(Hotel hotel, NavigationService<EquipmentTableVM> equipmentListingNavigationService)
        {
            SaveCommand = new AddEquipmentCommand(this, hotel, equipmentListingNavigationService);
            CancelCommand = new NavigateCommand(equipmentListingNavigationService);
        }
    }
}