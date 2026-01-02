using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class ScreenEquipmentOperationsVM : ScreenItemOperationsBase<EquipmentItem, EquipmentItemVM, ScreenEquipmentListingVM, ScreenEquipmentEditingVM>
    {
        private readonly HotelStore _hotelStore;

        public ScreenEquipmentOperationsVM(HotelStore hotelStore)
        {
            _hotelStore = hotelStore;
        }
        
        protected override Func<ScreenEquipmentListingVM> CreateListingScreen
        {
            get => () => new ScreenEquipmentListingVM(_hotelStore, EditingVM, NavigateToEditing);
        }
        
        protected override Func<ScreenEquipmentEditingVM> CreateEditingScreen
        {
            get => () => new ScreenEquipmentEditingVM(_hotelStore, NavigateToListing);
        }
    }
}