using System.Collections.ObjectModel;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Rooms
{
    public class ScreenRoomListingVM : ScreenListingVMBase<RoomItem, RoomItemVM>
    {
        #region Properties

        private ObservableCollection<RoomItemVM> _roomItems;

        public ObservableCollection<RoomItemVM> RoomItems
        {
            get { return _roomItems; }
            set { _roomItems = value; }
        }

        #endregion
        
        public ScreenRoomListingVM(HotelStore hotelStore, ScreenRoomEditingVM editVM, Action navigateToEdit) : base(hotelStore.Rooms, editVM, navigateToEdit)
        {
            _roomItems = new ObservableCollection<RoomItemVM>();
        }

        protected override ObservableCollection<RoomItemVM> Items { get => RoomItems; }
        protected override Func<RoomItem, RoomItemVM> CreateNewItemVM { get => item => new RoomItemVM(item); }
    }
}