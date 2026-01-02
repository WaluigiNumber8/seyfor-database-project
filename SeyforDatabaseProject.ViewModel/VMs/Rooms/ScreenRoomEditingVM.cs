using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Rooms
{
    /// <summary>
    /// A view model for editing room parameters.
    /// </summary>
    public class ScreenRoomEditingVM : ScreenEditingVMBase<RoomItem, RoomItemVM>
    {
        #region Properties

        private int _roomNumber;
        public int RoomNumber
        {
            get => _roomNumber;
            set
            {
                _roomNumber = value;
                OnPropertyChanged();
            }
        }

        private RoomType _roomType;
        public RoomType RoomType
        {
            get => _roomType;
            set
            {
                _roomType = value;
                OnPropertyChanged();
            }
        }

        private int _capacity;
        public int Capacity
        {
            get => _capacity;
            set
            {
                _capacity = value;
                OnPropertyChanged();
            }
        }

        private decimal _pricePerNight;
        public decimal PricePerNight
        {
            get => _pricePerNight;
            set
            {
                _pricePerNight = value;
                OnPropertyChanged();
            }
        }

        private RoomAvailabilityStatus _availabilityStatus;
        public RoomAvailabilityStatus AvailabilityStatus
        {
            get => _availabilityStatus;
            set
            {
                _availabilityStatus = value;
                OnPropertyChanged();
            }
        }
        #endregion
        
        public ScreenRoomEditingVM(HotelStore hotelStore, Action navigateToListing) : base(hotelStore.Rooms, navigateToListing)
        {
        }

        protected override Func<int, RoomItem> CreateItemFromFields { get => id => new RoomItem(id, RoomNumber, RoomType, Capacity, PricePerNight, AvailabilityStatus); }
        protected override string ItemTypeName { get => "Room"; }
        
        public override void ClearFields()
        {
            RoomNumber = 0;
            RoomType = RoomType.Single;
            Capacity = 1;
            PricePerNight = 0.0m;
            AvailabilityStatus = RoomAvailabilityStatus.Available;
        }

        protected override void SetPropertiesFromItem(RoomItemVM item)
        {
            RoomNumber = item.RoomNumber;
            RoomType = Enum.Parse<RoomType>(item.RoomType);
            Capacity = item.Capacity;
            PricePerNight = decimal.Parse(item.PricePerNight);
            AvailabilityStatus = Enum.Parse<RoomAvailabilityStatus>(item.AvailabilityStatus);
        }
    }
}