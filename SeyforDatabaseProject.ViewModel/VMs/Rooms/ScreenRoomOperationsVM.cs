using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Rooms
{
    public class ScreenRoomOperationsVM : ScreenItemOperationsBase<RoomItem, RoomItemVM, ScreenRoomListingVM, ScreenRoomEditingVM>
    {
        private HotelStore _hotelStore;

        public ScreenRoomOperationsVM(HotelStore hotelStore)
        {
            _hotelStore = hotelStore;
        }
        
        protected override Func<ScreenRoomListingVM> CreateListingScreen
        {
            get => () => new ScreenRoomListingVM(_hotelStore, EditingVM, NavigateToEditing);
        }
        
        protected override Func<ScreenRoomEditingVM> CreateEditingScreen
        {
            get => () => new ScreenRoomEditingVM(_hotelStore, NavigateToListing);
        }
    }
}