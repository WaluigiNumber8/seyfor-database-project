using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Validation;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class ScreenEquipmentEditingVM : ScreenEditingVMBase<EquipmentItem, EquipmentItemVM>
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

        public ScreenEquipmentEditingVM(HotelStore hotelStore, Action navigateToListing) : base(hotelStore.Equipment, navigateToListing) { }

        protected override Func<int, EquipmentItem> CreateItemFromFields
        {
            get => id => new EquipmentItem(id, Title, Description);
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

        protected override void AddValidationRules(IList<ValidationRule> validationRules)
        {
        }
    }
}