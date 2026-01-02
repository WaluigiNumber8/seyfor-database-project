using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Guests
{
    public class GuestItemVM : DatabaseItemVMBase<GuestItem>
    {
        public string Name { get => _item.Name; }
        public string Surname { get => _item.Surname; }
        public string Email { get => _item.Email; }
        public string PhoneNumber { get => _item.PhoneNumber; }
        
        public GuestItemVM(GuestItem item) : base(item) { }

        public override string ToString() => _item.ToString();
    }
}