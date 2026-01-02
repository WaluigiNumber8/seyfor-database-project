using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class ScreenEquipmentOperationsVM : ScreenItemOperationsBase<EquipmentItem, EquipmentItemVM, ScreenEquipmentListingVM, ScreenEquipmentEditingVM>
    {
        public ScreenEquipmentOperationsVM(HotelStore hotelStore)
        {
            ScreenEquipmentEditingVM editingVM = new(hotelStore, NavigateToListing);
            ScreenEquipmentListingVM listingVM = new(hotelStore, editingVM, NavigateToEditing);
            Construct(listingVM, editingVM);
        }
    }
}