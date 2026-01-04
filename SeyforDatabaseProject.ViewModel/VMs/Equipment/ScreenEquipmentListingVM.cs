using System.Collections.ObjectModel;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class ScreenEquipmentListingVM : ScreenListingVMBase<EquipmentItem, EquipmentItemVM>
    {

        public ScreenEquipmentListingVM(HotelStore hotelStore, ScreenEquipmentEditingVM editVM, Action navigateToEdit) : base(hotelStore.Equipment, editVM, navigateToEdit)
        {
        }

        protected override Func<EquipmentItem, EquipmentItemVM> CreateNewItemVM { get => item => new EquipmentItemVM(item); }
        
    }
}