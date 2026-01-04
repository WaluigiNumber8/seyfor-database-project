using System.Text.RegularExpressions;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Validation;

namespace SeyforDatabaseProject.ViewModel.Guests
{
    public class ScreenGuestEditVM : ScreenEditingVMBase<GuestItem, GuestItemVM>
    {
        #region Properties

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
                Validate(nameof(Name));
            }
        }

        private string _surname;

        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
                Validate(nameof(Surname));
            }
        }

        private string _email;

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged();
                Validate(nameof(Email));
            }
        }

        private string _phoneNumber;

        public string PhoneNumber
        {
            get => _phoneNumber;
            set
            {
                _phoneNumber = value;
                OnPropertyChanged();
                Validate(nameof(PhoneNumber));
            }
        }

        #endregion

        public ScreenGuestEditVM(HotelStore hotelStore, Action navigateToListing) : base(hotelStore.Guests, navigateToListing) { }

        protected override string ItemTypeName
        {
            get => "Guest";
        }

        protected override Func<int, GuestItem> CreateItemFromFields
        {
            get => id => new GuestItem(id, Name, Surname, Email, PhoneNumber);
        }

        public override void ClearFields()
        {
            Name = string.Empty;
            Surname = string.Empty;
            Email = string.Empty;
            PhoneNumber = string.Empty;
        }

        protected override void SetPropertiesFromItem(GuestItemVM item)
        {
            Name = item.Name;
            Surname = item.Surname;
            Email = item.Email;
            PhoneNumber = item.PhoneNumber;
        }

        protected override void AddValidationRules(IList<ValidationRule> validationRules)
        {
            validationRules.Add(new ValidationRule(nameof(Name), "Name cannot be empty", () => string.IsNullOrEmpty(Name)));
            validationRules.Add(new ValidationRule(nameof(Surname), "Surname cannot be empty", () => string.IsNullOrEmpty(Surname)));
            const string emailPattern = @"^[A-Za-z0-9._%+\-]+@[A-Za-z0-9.\-]+\.[A-Za-z]{2,}$";
            validationRules.Add(new ValidationRule(nameof(Email), "Email is not in a valid format", () => string.IsNullOrWhiteSpace(Email) || !Regex.IsMatch(Email, emailPattern)));
            validationRules.Add(new ValidationRule(nameof(PhoneNumber), "Phone number must have exactly 9 numbers", () => PhoneNumber.Length != 9));
        }
    }
}