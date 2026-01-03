using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.ViewModel.ContentBrowser;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Reservations
{
    public class ScreenReservationOperationsVM : ScreenItemOperationsBase<ReservationItem, ReservationItemVM, ScreenReservationListingVM, ScreenReservationEditingVM>
    {
        private readonly HotelStore _hotelStore;
        private readonly IServiceContentBrowser _browserService;

        public ScreenReservationOperationsVM(HotelStore hotelStore, IServiceContentBrowser browserService)
        {
            _browserService = browserService;
            _hotelStore = hotelStore;
        }

        protected override Func<ScreenReservationListingVM> CreateListingScreen
        {
            get => () => new ScreenReservationListingVM(_hotelStore, EditingVM, NavigateToEditing);
        }

        protected override Func<ScreenReservationEditingVM> CreateEditingScreen
        {
            get => () => new ScreenReservationEditingVM(_hotelStore, NavigateToListing, _browserService);
        }
    }
}