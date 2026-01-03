using SeyforDatabaseProject.Model.Data.Guests;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    public class ContentBrowserGuestVM : ContentBrowserVMBase<GuestItem>
    {
        public ContentBrowserGuestVM(HotelStore hotelStore) : base(hotelStore.Guests)
        {
        }

        protected override string GetAssetTextIdentifier(GuestItem item) => $"{item.Name} {item.Surname}";
    }
}