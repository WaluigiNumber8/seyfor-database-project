using System.Windows.Input;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.ViewModel.ContentBrowser;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Reservations
{
    public class ScreenReservationEditingVM : ScreenEditingVMBase<ReservationItem, ReservationItemVM>
    {
        private const string EmptyGuestText = "No Guest selected";
        private const string EmptyRoomText = "No Room selected";
        
        #region Properties

        private string _currentGuestText;

        public string CurrentGuestText
        {
            get => _currentGuestText;
            set
            {
                _currentGuestText = value;
                OnPropertyChanged();
            }
        }

        private string _currentRoomText;

        public string CurrentRoomText
        {
            get => _currentRoomText;
            set
            {
                _currentRoomText = value;
                OnPropertyChanged();
            }
        }
        
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
        public ICommand SelectRoomCommand { get; }

        #endregion

        private GuestItem _currentGuest;
        private RoomItem _currentRoom;


        public ScreenReservationEditingVM(HotelStore hotelStore, Action navigateToListing, IServiceContentBrowser browserService) : base(hotelStore.Reservations, navigateToListing)
        {
            SelectGuestCommand = new OpenContentBrowserCommand<GuestItem>(WhenGuestSelected, () => new ContentBrowserGuestVM(hotelStore.Guests, browserService), browserService);
            SelectRoomCommand = new OpenContentBrowserCommand<RoomItem>(WhenRoomSelected, () => new ContentBrowserRoomVM(hotelStore.Rooms, browserService), browserService);
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
            CurrentGuestText = EmptyGuestText;
            CurrentRoomText = EmptyRoomText;
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

        private void WhenGuestSelected(GuestItem guest)
        {
            Console.WriteLine($"Selected guest: {guest}");
            _currentGuest = guest;
            CurrentGuestText = guest.FullName;
        }
        
        private void WhenRoomSelected(RoomItem room)
        {
            Console.WriteLine($"Selected guest: {room}");
            _currentRoom = room;
            CurrentRoomText = room.RoomNumber.ToString();
        }
    }
}