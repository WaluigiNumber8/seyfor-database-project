using System.Collections.ObjectModel;
using System.Windows.Input;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Navigation;
using SeyforDatabaseProject.ViewModel.Rooms;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class EquipmentListingVM : DatabaseListingScreenBase<EquipmentItem, EquipmentItemVM>
    {
        #region Properties

        private ObservableCollection<EquipmentItemVM> _equipmentItems;

        public ObservableCollection<EquipmentItemVM> EquipmentItems
        {
            get { return _equipmentItems; }
            set { _equipmentItems = value; }
        }

        #endregion

        public ICommand AddEntryCommand { get; }
        public ICommand EditEntryCommand { get; }

        public EquipmentListingVM(HotelStore hotelStore, EquipmentEditVM editVM, NavigationService<EquipmentEditVM> equipmentEditNavigationService) : base(hotelStore, hotelStore.Equipment)
        {
            _equipmentItems = new ObservableCollection<EquipmentItemVM>();
            AddEntryCommand = new AddEquipmentCommand(equipmentEditNavigationService, editVM);
            EditEntryCommand = new EditEquipmentCommand(editVM, equipmentEditNavigationService);
        }

        protected override ObservableCollection<EquipmentItemVM> Items { get => EquipmentItems; }
        protected override Func<EquipmentItem, EquipmentItemVM> CreateNewItemVM { get => item => new EquipmentItemVM(item); }
    }
}