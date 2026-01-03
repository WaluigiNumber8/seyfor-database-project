using SeyforDatabaseProject.Model.Services;

namespace SeyforDatabaseProject.Model.Data
{
    /// <summary>
    /// Represents a room storeed in the database.
    /// </summary>
    public class RoomItem : DatabaseItemBase<RoomItem>
    {
        public int RoomNumber { get; private set; }
        public RoomType RoomType { get; private set; }
        public int Capacity { get; private set; }
        public decimal PricePerNight { get; private set; }
        public RoomAvailabilityStatus AvailabilityStatus { get; private set; }
        public List<EquipmentItem> Equipment { get; private set; }

        public RoomItem(int id, int roomNumber, RoomType roomType, int capacity, decimal pricePerNight, RoomAvailabilityStatus availabilityStatus, List<EquipmentItem> equipment)
        {
            ID = id;
            RoomNumber = roomNumber;
            RoomType = roomType;
            Capacity = capacity;
            PricePerNight = pricePerNight;
            AvailabilityStatus = availabilityStatus;
            Equipment = equipment;
        }

        protected override void UpdateFields(RoomItem item)
        {
            RoomNumber = item.RoomNumber;
            RoomType = item.RoomType;
            Capacity = item.Capacity;
            PricePerNight = item.PricePerNight;
            AvailabilityStatus = item.AvailabilityStatus;
            Equipment = item.Equipment;
        }

        public override string ToString() => $"{ID} - Room {RoomNumber} ({RoomType})";
    }
}