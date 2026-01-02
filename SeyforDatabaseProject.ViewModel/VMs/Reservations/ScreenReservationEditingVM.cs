using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Reservations
{
    public class ScreenReservationEditingVM : ScreenEditingVMBase<ReservationItem, ReservationItemVM>
    {
        #region Properties

        private DateTime _dateStart;

        public DateTime DateStart
        {
            get => _dateStart;
            set
            {
                _dateStart = value;
                OnPropertyChanged();
            }
        }

        private DateTime _dateEnd;

        public DateTime DateEnd
        {
            get => _dateEnd;
            set
            {
                _dateEnd = value;
                OnPropertyChanged();
            }
        }

        private ReservationStatus _state;

        public ReservationStatus State
        {
            get => _state;
            set
            {
                _state = value;
                OnPropertyChanged();
            }
        }

        private string _priceTotal;

        public string PriceTotal
        {
            get => _priceTotal;
            set
            {
                _priceTotal = value;
                OnPropertyChanged();
            }
        }

        //TODO: Add guest and room

        #endregion

        public ScreenReservationEditingVM(HotelStore hotelStore, Action navigateToListing) : base(hotelStore.Reservations, navigateToListing)
        {
        }

        protected override string ItemTypeName
        {
            get => "Reservation";
        }

        protected override Func<int, ReservationItem> CreateItemFromFields
        {
            get => id => new ReservationItem(id, DateStart, DateEnd, State, Convert.ToDecimal(PriceTotal));
        }

        public override void ClearFields()
        {
            DateStart = DateTime.Now;
            DateEnd = DateTime.Now;
            State = ReservationStatus.New;
            PriceTotal = "0";
        }

        protected override void SetPropertiesFromItem(ReservationItemVM item)
        {
            DateStart = Convert.ToDateTime(item.DateStart);
            DateEnd = Convert.ToDateTime(item.DateEnd);
            State = Enum.Parse<ReservationStatus>(item.State);
            PriceTotal = item.PriceTotal;
        }
    }
}