using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class EquipmentEditVM : ScreenEditVMBase<EquipmentItem, EquipmentItemVM, EquipmentListingVM, EquipmentEditVM>
    {
        #region Properties

        private string _title;

        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _description;

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public EquipmentEditVM(HotelStore hotelStore, NavigationService<EquipmentListingVM> navigateToListing) : base(hotelStore.Equipment, navigateToListing)
        {
        }

        protected override Func<EquipmentItem> CreateItemFromFields
        {
            get => () => new EquipmentItem(0, Title, Description);
        }

        protected override string ItemTypeName
        {
            get => "Equipment";
        }

        public override void ClearFields()
        {
            Title = string.Empty;
            Description = string.Empty;
        }

        protected override void SetPropertiesFromItem(EquipmentItemVM item)
        {
            Title = item.Title;
            Description = item.Description;
        }
    }
}