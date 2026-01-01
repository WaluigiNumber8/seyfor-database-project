using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Rooms
{
    /// <summary>
    /// A view model for editing room parameters.
    /// </summary>
    public class RoomEditVM : ScreenEditVMBase<RoomItem, RoomItemVM>
    {
        public RoomEditVM(HotelStore hotelStore, NavigationService<ScreenListingVMBase<RoomItem, RoomItemVM>> navigateToListing) : base(hotelStore.Rooms, navigateToListing)
        {
        }

        protected override Func<RoomItem> CreateItemFromFields { get; }
        protected override string ItemTypeName { get => "Room"; }
        
        public override void ClearFields()
        {
        }

        protected override void SetPropertiesFromItem(RoomItemVM item)
        {
        }
    }
}