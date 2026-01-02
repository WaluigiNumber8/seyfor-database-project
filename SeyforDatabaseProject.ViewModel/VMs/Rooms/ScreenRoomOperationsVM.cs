using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Rooms
{
    public class ScreenRoomOperationsVM : ScreenItemOperationsBase<RoomItem, RoomItemVM, ScreenRoomListingVM, ScreenRoomEditingVM>
    {
        public ScreenRoomOperationsVM(HotelStore store)
        {
            ScreenRoomEditingVM editing = new(store, NavigateToListing);
            ScreenRoomListingVM listing = new(store, editing, NavigateToEditing);
            Construct(listing, editing);
        }
    }
}