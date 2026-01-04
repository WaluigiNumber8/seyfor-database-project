using System.Collections.ObjectModel;
using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Reservations
{
    public class ScreenReservationListingVM : ScreenListingVMBase<ReservationItem, ReservationItemVM>
    {
        
        public ScreenReservationListingVM(HotelStore hotelStore, ScreenReservationEditingVM editVM, Action navigateToEdit) : base(hotelStore.Reservations, editVM, navigateToEdit)
        {
        }

        protected override Func<ReservationItem, ReservationItemVM> CreateNewItemVM { get => item => new ReservationItemVM(item); }
    }
}