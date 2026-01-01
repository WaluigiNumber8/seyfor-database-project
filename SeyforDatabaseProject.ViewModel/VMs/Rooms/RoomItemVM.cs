using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Equipment;

namespace SeyforDatabaseProject.ViewModel.Rooms
{
    public class RoomItemVM : DatabaseItemVMBase<RoomItem>
    {
        public int RoomNumber { get => _item.RoomNumber; }
        public string RoomType { get => _item.RoomType.ToString(); }
        public int Capacity { get => _item.Capacity; }
        public string PricePerNight { get => _item.PricePerNight.ToString(); }
        public string AvailabilityStatus { get => _item.AvailabilityStatus.ToString(); }
        public string Equipment {get => string.Join(", ", _item.Equipment); }
        
        public RoomItemVM(RoomItem item) : base(item) { }


        public override string ToString() => _item.ToString();
    }
}