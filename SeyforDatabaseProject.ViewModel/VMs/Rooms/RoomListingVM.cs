using System.Collections.ObjectModel;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Rooms
{
    public class RoomListingVM : ScreenListingVMBase<RoomItem, RoomItemVM>
    {
        #region Properties

        private ObservableCollection<RoomItemVM> _roomItems;

        public ObservableCollection<RoomItemVM> RoomItems
        {
            get { return _roomItems; }
            set { _roomItems = value; }
        }

        #endregion
        
        public RoomListingVM(HotelStore hotelStore, RoomEditVM editVM, NavigationService<RoomEditVM> roomEditNavigationService) : base(hotelStore.Rooms, editVM, roomEditNavigationService)
        {
            _roomItems = new ObservableCollection<RoomItemVM>();
        }

        protected override ObservableCollection<RoomItemVM> Items { get => RoomItems; }
        protected override Func<RoomItem, RoomItemVM> CreateNewItemVM { get => item => new RoomItemVM(item); }
    }
}