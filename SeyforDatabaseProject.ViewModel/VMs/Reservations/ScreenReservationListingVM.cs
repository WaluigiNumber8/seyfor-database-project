using System.Collections.ObjectModel;
using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Reservations
{
    public class ScreenReservationListingVM : ScreenListingVMBase<ReservationItem, ReservationItemVM>
    {
        #region Properties

        private ObservableCollection<ReservationItemVM> _reservationItems;

        public ObservableCollection<ReservationItemVM> ReservationItems
        {
            get { return _reservationItems; }
            set { _reservationItems = value; }
        }

        #endregion
        
        public ScreenReservationListingVM(HotelStore hotelStore, ScreenReservationEditingVM editVM, Action navigateToEdit) : base(hotelStore.Reservations, editVM, navigateToEdit)
        {
            _reservationItems = new ObservableCollection<ReservationItemVM>();
        }

        protected override ObservableCollection<ReservationItemVM> Items { get => ReservationItems; }
        protected override Func<ReservationItem, ReservationItemVM> CreateNewItemVM { get => item => new ReservationItemVM(item); }
    }
}