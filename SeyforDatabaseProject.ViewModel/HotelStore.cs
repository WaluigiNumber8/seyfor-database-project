using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.Model.Data.Reservations;

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
        public DatabaseItemList<ReservationItem> Reservations { get; }

        public HotelStore(Hotel hotel)
        {
            Equipment = new DatabaseItemList<EquipmentItem>(hotel);
            Rooms = new DatabaseItemList<RoomItem>(hotel);
            Guests = new DatabaseItemList<GuestItem>(hotel);
            Reservations = new DatabaseItemList<ReservationItem>(hotel);
        }
    }
}