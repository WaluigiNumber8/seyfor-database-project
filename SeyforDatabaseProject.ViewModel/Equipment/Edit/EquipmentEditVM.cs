using System.Windows.Input;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class EquipmentEditVM : ViewModelBase
    {
        #region Properties

        private string _headerText;
        public string HeaderText
        {
            get => _headerText;
            set
            {
                _headerText = value;
                OnPropertyChanged();
            }
        }

        private string _saveButtonText;

        public string SaveButtonText
        {
            get => _saveButtonText;
            set
            {
                _saveButtonText = value;
                OnPropertyChanged();
            }
        }

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

        private readonly ICommand _saveChangesCommand;
        private readonly ICommand _saveNewCommand;
        public EquipmentItemVM? CurrentItem { get; private set; }

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; }
        public ICommand RemoveCommand { get; }

        public EquipmentEditVM(HotelStore hotelStore, NavigationService<EquipmentListingVM> navigateToEquipmentList)
        {
            _saveNewCommand = new SaveNewEquipmentCommand(this, hotelStore, navigateToEquipmentList);
            _saveChangesCommand = new SaveEquipmentChangesCommand(this, hotelStore, navigateToEquipmentList);
            SaveCommand = _saveNewCommand;
            CancelCommand = new NavigateCommand(navigateToEquipmentList);
            RemoveCommand = new RemoveEquipmentCommand(this, hotelStore, navigateToEquipmentList);
        }
        
        public void LoadForEdit(EquipmentItemVM? item)
        {
            CurrentItem = item;
            if (CurrentItem == null)
            {
                ClearFields();
                return;
            }
            
            HeaderText = $"Editing Equipment: {CurrentItem.Title}";
            SaveButtonText = "Save";
            
            Title = CurrentItem.Title;
            Description = CurrentItem.Description;

            SaveCommand = _saveChangesCommand;
        }
        
        public void LoadForAdd()
        {
            CurrentItem = null;
            HeaderText = "Adding New Equipment";
            SaveButtonText = "Add";
            ClearFields();
            
            SaveCommand = _saveNewCommand;
        }
        
        public void ClearFields()
        {
            Title = "";
            Description = "";
        }
    }
}