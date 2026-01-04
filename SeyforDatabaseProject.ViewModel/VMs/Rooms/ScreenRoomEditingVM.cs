using System.Text;
using System.Windows.Input;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.ContentBrowser;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Validation;

namespace SeyforDatabaseProject.ViewModel.Rooms
{
    /// <summary>
    /// A view model for editing room parameters.
    /// </summary>
    public class ScreenRoomEditingVM : ScreenEditingVMBase<RoomItem, RoomItemVM>
    {
        private const string NoEquipmentText = "No Equipment selected";
        
        #region Properties

        private int _roomNumber;
        public int RoomNumber
        {
            get => _roomNumber;
            set
            {
                _roomNumber = value;
                OnPropertyChanged();
                Validate(nameof(RoomNumber));
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
                Validate(nameof(RoomType));
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
                Validate(nameof(Capacity));
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
                Validate(nameof(PricePerNight));
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
                Validate(nameof(AvailabilityStatus));
            }
        }

        private string _currentEquipmentText;

        public string CurrentEquipmentText
        {
            get => _currentEquipmentText;
            set
            {
                _currentEquipmentText = value;
                OnPropertyChanged();
                Validate(nameof(CurrentEquipmentText));
            }
        }
        #endregion
        
        public ICommand SelectEquipmentCommand { get; }
        
        private readonly HotelStore _hotelStore;
        private List<EquipmentItem> _currentEquipment;
        private int? _currentID;

        public ScreenRoomEditingVM(HotelStore hotelStore, Action navigateToListing, IServiceContentBrowser browserService) : base(hotelStore.Rooms, navigateToListing)
        {
            _hotelStore = hotelStore;
            SelectEquipmentCommand = new OpenContentBrowserCommand<EquipmentItem>(WhenEquipmentSelected, () => new ContentBrowserEquipmentVM(hotelStore.Equipment, browserService), browserService);
        }

        protected override Func<int, RoomItem> CreateItemFromFields { get => id => new RoomItem(id, RoomNumber, RoomType, Capacity, PricePerNight, AvailabilityStatus, _currentEquipment); }
        protected override string ItemTypeName { get => "Room"; }
        
        public override void ClearFields()
        {
            RoomNumber = 0;
            RoomType = RoomType.Single;
            Capacity = 1;
            PricePerNight = 0.0m;
            AvailabilityStatus = RoomAvailabilityStatus.Available;
            CurrentEquipmentText = NoEquipmentText;
            _currentEquipment = new List<EquipmentItem>();
            _currentID = null;
        }

        protected override void SetPropertiesFromItem(RoomItemVM item)
        {
            _currentID = item.ID;
            RoomNumber = item.RoomNumber;
            RoomType = Enum.Parse<RoomType>(item.RoomType);
            Capacity = item.Capacity;
            PricePerNight = item.PricePerNight;
            AvailabilityStatus = Enum.Parse<RoomAvailabilityStatus>(item.AvailabilityStatus);
            _currentEquipment = item.Equipment;
            CurrentEquipmentText = item.EquipmentText;

        }

        protected override void AddValidationRules(IList<ValidationRule> validationRules)
        {
            validationRules.Add(new ValidationRule(nameof(RoomNumber), "Room Number must be above 0.", () => RoomNumber <= 0));
            validationRules.Add(new ValidationRule(nameof(RoomNumber), "There is already a room with this number.", () => _hotelStore.Rooms.Items.FirstOrDefault(r => r.ID != _currentID && r.RoomNumber == RoomNumber) != null));
            validationRules.Add(new ValidationRule(nameof(Capacity), "Capacity must be above 0.", () => Capacity <= 0));
            validationRules.Add(new ValidationRule(nameof(PricePerNight), "Price must be above 0.", () => PricePerNight <= 0));
        }

        private void WhenEquipmentSelected(IList<EquipmentItem> items)
        {
            _currentEquipment = items.ToList();
            StringBuilder sb = new();
            foreach (EquipmentItem item in items)
            {
                sb.Append($"{item.Title}, ");
            }
            CurrentEquipmentText = sb.ToString();
        }
    }
}