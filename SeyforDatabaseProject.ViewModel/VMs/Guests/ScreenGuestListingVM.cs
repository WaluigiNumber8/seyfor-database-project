using System.Collections.ObjectModel;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Guests
{
    public class ScreenGuestListingVM : ScreenListingVMBase<GuestItem, GuestItemVM>
    {
        #region Properties

        private ObservableCollection<GuestItemVM> _guestItems;
        public ObservableCollection<GuestItemVM> GuestItems
        {
            get { return _guestItems; }
            set { _guestItems = value; }
        }

        #endregion

        public ScreenGuestListingVM(HotelStore hotelStore, ScreenEditingVMBase<GuestItem, GuestItemVM> editVM, Action navigateToEdit) : base(hotelStore.Guests, editVM, navigateToEdit)
        {
            _guestItems = new ObservableCollection<GuestItemVM>();
        }

        protected override ObservableCollection<GuestItemVM> Items { get => GuestItems; }
        protected override Func<GuestItem, GuestItemVM> CreateNewItemVM { get => item => new GuestItemVM(item); }
    }
}