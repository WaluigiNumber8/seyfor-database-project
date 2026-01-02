using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Data.Guests;

namespace SeyforDatabaseProject.ViewModel
{
    /// <summary>
    /// Single access point for hotel data in the ViewModel layer.
    /// </summary>
    public class HotelStore
    {
        public DatabaseItemList<EquipmentItem> Equipment { get; }
        public DatabaseItemList<RoomItem> Rooms { get; }
        public DatabaseItemList<GuestItem> Guests { get; }

        public HotelStore(Hotel hotel)
        {
            Equipment = new DatabaseItemList<EquipmentItem>(hotel);
            Rooms = new DatabaseItemList<RoomItem>(hotel);
            Guests = new DatabaseItemList<GuestItem>(hotel);
        }
    }
}