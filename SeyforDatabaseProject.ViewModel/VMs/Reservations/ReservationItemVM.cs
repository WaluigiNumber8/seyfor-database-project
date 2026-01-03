using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Reservations
{
    public class ReservationItemVM : DatabaseItemVMBase<ReservationItem>
    {
        public string Guest { get => _item.Guest.FullName; }
        public string Room { get => _item.Room.RoomNumber.ToString(); }
        public string DateStart { get => _item.DateStart.ToString(); }
        public string DateEnd { get => _item.DateEnd.ToString(); }
        public string State { get => _item.State.ToString(); }
        public string PriceTotal { get => _item.PriceTotal.ToString(); }
        
        public ReservationItemVM(ReservationItem item) : base(item) { }

        public override string ToString() => _item.ToString();
    }
}