using SeyforDatabaseProject.Model.Data.Guests;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    public class ContentBrowserGuestVM : ContentBrowserVMBase<GuestItem>
    {
        public ContentBrowserGuestVM(HotelStore hotelStore, IServiceContentBrowser browserService) : base(hotelStore.Guests, browserService)
        {
        }

        protected override string GetAssetTextIdentifier(GuestItem item) => $"{item.Name} {item.Surname}";
    }
}