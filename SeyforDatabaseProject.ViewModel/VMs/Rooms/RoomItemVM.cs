using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Rooms
{
    public class RoomItemVM : DatabaseItemVMBase<RoomItem>
    {
        public int RoomNumber { get => _item.RoomNumber; }
        public string RoomType { get => _item.RoomType.ToString(); }
        public int Capacity { get => _item.Capacity; }
        public decimal PricePerNight { get => _item.PricePerNight; }
        public string PricePerNightWithCurrency { get => $"{_item.PricePerNight} Kč"; }
        public string AvailabilityStatus { get => _item.AvailabilityStatus.ToString(); }
        public string EquipmentText {get => string.Join(", ", _item.Equipment); }
        public List<EquipmentItem> Equipment {get => _item.Equipment;}
        
        public RoomItemVM(RoomItem item) : base(item) { }

        public override string ToString() => _item.ToString();
    }
}