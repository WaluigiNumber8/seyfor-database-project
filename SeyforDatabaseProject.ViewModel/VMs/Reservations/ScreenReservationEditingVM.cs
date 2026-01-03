using System.Windows.Input;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.ViewModel.ContentBrowser;
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

        #endregion

        #region Commands

        public ICommand SelectGuestCommand { get; }

        #endregion

        private GuestItem _currentGuest;


        public ScreenReservationEditingVM(HotelStore hotelStore, Action navigateToListing, IServiceContentBrowser browserService) : base(hotelStore.Reservations, navigateToListing)
        {
            SelectGuestCommand = new OpenContentBrowserForGuestsCommand(hotelStore, WhenGuestSelected, browserService);
        }

        protected override string ItemTypeName
        {
            get => "Reservation";
        }

        protected override Func<int, ReservationItem> CreateItemFromFields
        {
            get => id => new ReservationItem(id, _currentGuest, DateStart, DateEnd, State, Convert.ToDecimal(PriceTotal));
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

        private void WhenGuestSelected(GuestItem guest) => _currentGuest = guest;
    }
}