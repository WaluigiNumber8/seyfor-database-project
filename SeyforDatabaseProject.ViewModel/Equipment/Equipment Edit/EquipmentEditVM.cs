using System;
using System.Windows.Input;
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
        
        private EquipmentItemVM? _currentItem;
        
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EquipmentEditVM(HotelStore hotelStore, NavigationService<EquipmentListingVM> navigateToEquipmentList)
        {
            SaveCommand = new SaveEquipmentCommand(this, hotelStore, navigateToEquipmentList);
            CancelCommand = new NavigateCommand(navigateToEquipmentList);
        }
        
        public void Load(EquipmentItemVM? item)
        {
            _currentItem = item;
            if (_currentItem == null)
            {
                ClearFields();
                return;
            }
            
            Title = _currentItem.Title;
            Description = _currentItem.Description;
        }
        
        public void ClearFields()
        {
            Title = "";
            Console.WriteLine("Clearing description field");
            Description = "";
        }
    }
}