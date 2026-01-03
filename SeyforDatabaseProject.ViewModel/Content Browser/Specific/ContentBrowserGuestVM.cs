using SeyforDatabaseProject.Model.Data.Guests;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    public class ContentBrowserGuestVM : ContentBrowserVMBase<GuestItem>
    {
        public ContentBrowserGuestVM(DatabaseItemList<GuestItem> list, IServiceContentBrowser browserService) : base(list, browserService)
        {
        }

        protected override string GetAssetTextIdentifier(GuestItem item) => $"{item.Name} {item.Surname}";
        
        protected override string AssetTypeInString { get => "Guest"; }
    }
}