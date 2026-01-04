using System.Collections;
using System.ComponentModel;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Validation;

namespace SeyforDatabaseProject.ViewModel.Guests
{
    public class ScreenGuestEditVM : ScreenEditingVMBase<GuestItem, GuestItemVM>, INotifyDataErrorInfo
    {
        private readonly VMValidationHandler _errors;
        
        #region Properties

        private string _name;

        public string Name
        {
            get => _name;
            set
            {
                _errors.ClearErrors(nameof(Name));
                _name = value;
                OnPropertyChanged();
                if (_name.Length <= 0)
                {
                    _errors.AddError(nameof(Name), "Name cannot be empty.");
                }
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
            }
        }
        
        #endregion

        public ScreenGuestEditVM(HotelStore hotelStore, Action navigateToListing) : base(hotelStore.Guests, navigateToListing)
        {
            _errors = new VMValidationHandler();
            _errors.ErrorsChanged += WhenErrorsChange;
        }

        protected override string ItemTypeName { get => "Guest"; }
        protected override Func<int, GuestItem> CreateItemFromFields { get => id => new GuestItem(id, Name, Surname, Email, PhoneNumber); }
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

        public IEnumerable GetErrors(string? propertyName) => _errors.GetErrors(propertyName);

        public bool HasErrors { get => _errors.HasErrors; }
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;
        private void WhenErrorsChange(object? sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(sender, e);
        }
    }
}