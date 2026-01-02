using System.Collections.ObjectModel;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class ScreenEquipmentListingVM : ScreenListingVMBase<EquipmentItem, EquipmentItemVM>
    {
        #region Properties

        private ObservableCollection<EquipmentItemVM> _equipmentItems;

        public ObservableCollection<EquipmentItemVM> EquipmentItems
        {
            get { return _equipmentItems; }
            set { _equipmentItems = value; }
        }

        #endregion

        public ScreenEquipmentListingVM(HotelStore hotelStore, ScreenEquipmentEditingVM editVM, Action navigateToEdit) : base(hotelStore.Equipment, editVM, navigateToEdit)
        {
            _equipmentItems = new ObservableCollection<EquipmentItemVM>();
        }

        protected override ObservableCollection<EquipmentItemVM> Items { get => EquipmentItems; }
        protected override Func<EquipmentItem, EquipmentItemVM> CreateNewItemVM { get => item => new EquipmentItemVM(item); }
        
    }
}