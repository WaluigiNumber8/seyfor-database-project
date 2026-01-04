using System.Text;
using System.Windows.Input;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.Model.Utils;
using SeyforDatabaseProject.ViewModel.ContentBrowser;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Validation;

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
                Validate(nameof(CurrentGuestText));
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
                Validate(nameof(CurrentRoomText));
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
                Validate(nameof(DateStart));
                Validate(nameof(DateEnd));
                OnPropertyChanged();
                RecalculatePrice();
            }
        }

        private DateTime _dateEnd;

        public DateTime DateEnd
        {
            get => _dateEnd;
            set
            {
                _dateEnd = value;
                Validate(nameof(DateEnd));
                Validate(nameof(DateStart));
                OnPropertyChanged();
                RecalculatePrice();
            }
        }

        private ReservationStatus _state;

        public ReservationStatus State
        {
            get => _state;
            set
            {
                _state = value;
                Validate(nameof(State));
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

        private string _conflictText;

        public string ConflictText
        {
            get => _conflictText;
            set
            {
                _conflictText = value;
                OnPropertyChanged();
            }
        }

        #endregion

        #region Commands

        public ICommand SelectGuestCommand { get; }
        public ICommand SelectRoomCommand { get; }

        #endregion

        private readonly HotelStore _hotelStore;

        private int? _currentID;
        private GuestItem? _currentGuest;
        private RoomItem? _currentRoom;


        public ScreenReservationEditingVM(HotelStore hotelStore, Action navigateToListing, IServiceContentBrowser browserService) : base(hotelStore.Reservations, navigateToListing)
        {
            _hotelStore = hotelStore;
            SelectGuestCommand = new OpenContentBrowserCommand<GuestItem>(WhenGuestSelected, () => new ContentBrowserGuestVM(hotelStore.Guests, browserService), browserService);
            SelectRoomCommand = new OpenContentBrowserCommand<RoomItem>(WhenRoomSelected, () => new ContentBrowserRoomVM(hotelStore.Rooms, browserService), browserService);
        }

        protected override string ItemTypeName
        {
            get => "Reservation";
        }

        protected override Func<int, ReservationItem> CreateItemFromFields
        {
            get => id => new ReservationItem(id, _currentGuest!, _currentRoom!, DateStart, DateEnd, State);
        }

        public override void ClearFields()
        {
            _currentID = null;
            _currentGuest = null;
            CurrentGuestText = EmptyGuestText;
            _currentRoom = null;
            CurrentRoomText = EmptyRoomText;
            DateStart = DateTime.Today;
            DateEnd = DateTime.Today;
            State = ReservationStatus.New;
            PriceTotal = "0";
            ConflictText = string.Empty;
        }

        protected override void SetPropertiesFromItem(ReservationItemVM item)
        {
            _currentID = item.ID;
            _currentGuest = item.Guest;
            CurrentGuestText = item.GuestText;
            _currentRoom = item.Room;
            CurrentRoomText = item.RoomText;
            DateStart = Convert.ToDateTime(item.DateStart);
            DateEnd = Convert.ToDateTime(item.DateEnd);
            State = Enum.Parse<ReservationStatus>(item.State);
            PriceTotal = item.PriceTotal;
        }

        protected override void AddValidationRules(IList<ValidationRule> validationRules)
        {
            validationRules.Add(new ValidationRule(nameof(CurrentGuestText), "Guest must be selected.", () => _currentGuest == null));
            validationRules.Add(new ValidationRule(nameof(CurrentRoomText), "Room must be selected.", () => _currentRoom == null));
            validationRules.Add(new ValidationRule(nameof(CurrentRoomText), "Room is currently out of service.", () => _currentRoom?.AvailabilityStatus == RoomAvailabilityStatus.OutOfService));
            validationRules.Add(new ValidationRule(nameof(DateStart), "Start Date cannot be in the past.", () => DateStart < DateTime.Today));
            validationRules.Add(new ValidationRule(nameof(DateStart), "Start Date is conflicting with another reservation.", IsReservationForThisRoomThisTimeRangeTaken));
            validationRules.Add(new ValidationRule(nameof(DateStart), "Start Date must be before end date.", () => DateStart >= DateEnd));
            validationRules.Add(new ValidationRule(nameof(DateEnd), "End Date cannot be in the past.", () => DateEnd < DateTime.Today));
            validationRules.Add(new ValidationRule(nameof(DateEnd), "End Date cannot be today.", () => DateEnd == DateTime.Today));
            validationRules.Add(new ValidationRule(nameof(DateEnd), "End Date must be after start date.", () => DateEnd <= DateStart));
        }

        private bool IsReservationForThisRoomThisTimeRangeTaken()
        {
            if (_currentRoom == null) return false;
            IList<ReservationItem> conflicts = _hotelStore.Reservations.Items.Where(r => (_currentID != r.ID) &&
                                                                                         _currentRoom!.ID == r.Room.ID &&
                                                                                         (r.DateStart.WithinRange(DateStart, DateEnd) ||
                                                                                          r.DateEnd.WithinRange(DateStart, DateEnd))).ToList();
            bool conflictFound = conflicts.Count > 0;

            if (!conflictFound)
            {
                ConflictText = string.Empty;
                return conflictFound;
            }

            StringBuilder sb = new();
            foreach (ReservationItem conflict in conflicts)
            {
                sb.AppendLine($"Reservation is conflicting with {conflict}.");
            }

            ConflictText = sb.ToString();
            return conflictFound;
        }

        private void WhenGuestSelected(IList<GuestItem> guestItems)
        {
            GuestItem guest = guestItems[0];
            Console.WriteLine($"Selected guest: {guest}");
            _currentGuest = guest;
            CurrentGuestText = guest.FullName;
        }

        private void WhenRoomSelected(IList<RoomItem> roomItems)
        {
            RoomItem room = roomItems[0];
            Console.WriteLine($"Selected room: {room}");
            _currentRoom = room;
            CurrentRoomText = room.RoomNumber.ToString();
            RecalculatePrice();
        }
        
        private void RecalculatePrice()
        {
            if (_currentRoom == null)
            {
                PriceTotal = "--";
                return;
            }

            decimal price = ReservationCalculations.CalculatePrice(DateStart, DateEnd, _currentRoom);
            PriceTotal = $"{price} Kč";
        }
    }
}