namespace SeyforDatabaseProject.Model.Data.Guests
{
    /// <summary>
    /// Represents a Guest item from the database.
    /// </summary>
    public class GuestItem : DatabaseItemBase<GuestItem>
    {
        public string Name { get; private set; }
        public string Surname { get; private set; }
        public string Email { get; private set; }
        public string PhoneNumber { get; private set; }

        public GuestItem(int id, string name, string surname, string email, string phoneNumber)
        {
            ID = id;
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
        }

        protected override void UpdateFields(GuestItem item)
        {
            Name = item.Name;
            Surname = item.Surname;
            Email = item.Email;
            PhoneNumber = item.PhoneNumber;
        }

        public string FullName {get => $"{Name} {Surname}";}
        
        public override string ToString() => $"{ID} - {Name} {Surname}";
    }
}