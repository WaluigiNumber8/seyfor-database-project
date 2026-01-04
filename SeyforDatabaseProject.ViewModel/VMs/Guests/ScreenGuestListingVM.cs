using System.Collections.ObjectModel;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Guests
{
    public class ScreenGuestListingVM : ScreenListingVMBase<GuestItem, GuestItemVM>
    {

        public ScreenGuestListingVM(HotelStore hotelStore, ScreenEditingVMBase<GuestItem, GuestItemVM> editVM, Action navigateToEdit) : base(hotelStore.Guests, editVM, navigateToEdit)
        {
        }

        protected override Func<GuestItem, GuestItemVM> CreateNewItemVM { get => item => new GuestItemVM(item); }
    }
}