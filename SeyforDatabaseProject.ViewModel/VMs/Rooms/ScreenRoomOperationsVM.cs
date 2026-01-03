using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.ContentBrowser;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Rooms
{
    public class ScreenRoomOperationsVM : ScreenItemOperationsBase<RoomItem, RoomItemVM, ScreenRoomListingVM, ScreenRoomEditingVM>
    {
        private readonly HotelStore _hotelStore;
        private readonly IServiceContentBrowser _browserService;

        public ScreenRoomOperationsVM(HotelStore hotelStore, IServiceContentBrowser browserService)
        {
            _browserService = browserService;
            _hotelStore = hotelStore;
        }
        
        protected override Func<ScreenRoomListingVM> CreateListingScreen
        {
            get => () => new ScreenRoomListingVM(_hotelStore, EditingVM, NavigateToEditing);
        }
        
        protected override Func<ScreenRoomEditingVM> CreateEditingScreen
        {
            get => () => new ScreenRoomEditingVM(_hotelStore, NavigateToListing, _browserService);
        }
    }
}