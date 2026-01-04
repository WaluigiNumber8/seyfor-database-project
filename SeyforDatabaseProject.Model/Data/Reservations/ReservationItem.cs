using SeyforDatabaseProject.Model.Data.Guests;

namespace SeyforDatabaseProject.Model.Data.Reservations
{
    /// <summary>
    /// Represents the Reservation Item from database.
    /// </summary>
    public class ReservationItem : DatabaseItemBase<ReservationItem>
    {
        public GuestItem Guest { get; private set; }
        public RoomItem Room { get; private set; }
        public DateTime DateStart { get; private set; }
        public DateTime DateEnd { get; private set; }
        public ReservationStatus State { get; private set; }
        public decimal PriceTotal { get; private set; }

        public ReservationItem(int id, GuestItem guest, RoomItem room, DateTime dateStart, DateTime dateEnd, ReservationStatus state)
        {
            ID = id;
            Guest = guest;
            Room = room;
            DateStart = dateStart;
            DateEnd = dateEnd;
            State = state;
            PriceTotal = ReservationCalculations.CalculatePrice(DateStart, DateEnd, Room);
        }

        protected override void UpdateFields(ReservationItem item)
        {
            Guest = item.Guest;
            Room = item.Room;
            DateStart = item.DateStart;
            DateEnd = item.DateEnd;
            State = item.State;
            PriceTotal = ReservationCalculations.CalculatePrice(DateStart, DateEnd, Room);
        }

        public override string ToString() => $"|{DateStart} - {DateEnd}| -- {Room} - {Guest}";
    }
}