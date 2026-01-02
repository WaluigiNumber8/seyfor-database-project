using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Guests
{
    public class ScreenGuestOperationsVM : ScreenItemOperationsBase<GuestItem, GuestItemVM, ScreenGuestListingVM, ScreenGuestEditingVM>
    {
        private readonly HotelStore _hotelStore;

        public ScreenGuestOperationsVM(HotelStore hotelStore)
        {
            _hotelStore = hotelStore;
        }

        protected override Func<ScreenGuestListingVM> CreateListingScreen
        {
            get => () => new ScreenGuestListingVM(_hotelStore, EditingVM, NavigateToEditing);
        }

        protected override Func<ScreenGuestEditingVM> CreateEditingScreen
        {
            get => () => new ScreenGuestEditingVM(_hotelStore, NavigateToListing);
        }
    }
}