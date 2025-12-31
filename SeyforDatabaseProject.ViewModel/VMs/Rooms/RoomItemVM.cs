using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Rooms
{
    public class RoomItemVM : ViewModelBase
    {
        public int ID { get => _item.ID; }
        public int RoomNumber { get => _item.RoomNumber; }
        public string RoomType { get => _item.RoomType.ToString(); }
        public int Capacity { get => _item.Capacity; }
        public string PricePerNight { get => _item.PricePerNight.ToString(); }
        public string AvailabilityStatus { get => _item.AvailabilityStatus.ToString(); }
        public string Equipment {get => string.Join(", ", _item.Equipment); }
        
        private readonly RoomItem _item;

        public RoomItemVM(RoomItem item)
        {
            _item = item;
        }

        public override string ToString() => _item.ToString();
    }
}