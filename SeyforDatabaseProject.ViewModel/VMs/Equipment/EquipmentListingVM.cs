using System.Collections.ObjectModel;
using System.Windows.Input;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class EquipmentListingVM : ScreenListingVMBase<EquipmentItem, EquipmentItemVM>
    {
        #region Properties

        private ObservableCollection<EquipmentItemVM> _equipmentItems;

        public ObservableCollection<EquipmentItemVM> EquipmentItems
        {
            get { return _equipmentItems; }
            set { _equipmentItems = value; }
        }

        #endregion

        public EquipmentListingVM(HotelStore hotelStore, EquipmentEditVM editVM, NavigationService<EquipmentEditVM> navigateToEdit) : base(hotelStore.Equipment, editVM, navigateToEdit)
        {
            _equipmentItems = new ObservableCollection<EquipmentItemVM>();
        }

        protected override ObservableCollection<EquipmentItemVM> Items { get => EquipmentItems; }
        protected override Func<EquipmentItem, EquipmentItemVM> CreateNewItemVM { get => item => new EquipmentItemVM(item); }
        
    }
}