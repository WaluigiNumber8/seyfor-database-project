using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.ViewModel
{
    /// <summary>
    /// Single access point for hotel data in the ViewModel layer.
    /// </summary>
    public class HotelStore
    {
        public DatabaseItemList<EquipmentItem> Equipment { get; }
        public DatabaseItemList<RoomItem> Rooms { get; }

        public HotelStore(Hotel hotel)
        {
            Equipment = new DatabaseItemList<EquipmentItem>(hotel);
            Rooms = new DatabaseItemList<RoomItem>(hotel);
        }

    }
}