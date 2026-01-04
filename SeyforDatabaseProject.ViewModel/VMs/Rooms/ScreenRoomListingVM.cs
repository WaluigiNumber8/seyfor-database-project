using System.Collections.ObjectModel;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Rooms
{
    public class ScreenRoomListingVM : ScreenListingVMBase<RoomItem, RoomItemVM>
    {
        public ScreenRoomListingVM(HotelStore hotelStore, ScreenRoomEditingVM editVM, Action navigateToEdit) : base(hotelStore.Rooms, editVM, navigateToEdit)
        {
        }

        protected override Func<RoomItem, RoomItemVM> CreateNewItemVM { get => item => new RoomItemVM(item); }
    }
}