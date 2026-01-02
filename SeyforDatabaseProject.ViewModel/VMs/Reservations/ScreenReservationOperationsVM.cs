using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Reservations
{
    public class ScreenReservationOperationsVM : ScreenItemOperationsBase<ReservationItem, ReservationItemVM, ScreenReservationListingVM, ScreenReservationEditingVM>
    {
        private HotelStore _hotelStore;

        public ScreenReservationOperationsVM(HotelStore hotelStore)
        {
            _hotelStore = hotelStore;
        }

        protected override Func<ScreenReservationListingVM> CreateListingScreen
        {
            get => () => new ScreenReservationListingVM(_hotelStore, EditingVM, NavigateToEditing);
        }

        protected override Func<ScreenReservationEditingVM> CreateEditingScreen
        {
            get => () => new ScreenReservationEditingVM(_hotelStore, NavigateToListing);
        }
    }
}