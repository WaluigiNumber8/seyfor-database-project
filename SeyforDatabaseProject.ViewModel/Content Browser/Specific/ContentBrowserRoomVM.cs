using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    public class ContentBrowserRoomVM : ContentBrowserVMBase<RoomItem>
    {
        public ContentBrowserRoomVM(DatabaseItemList<RoomItem> list, IServiceContentBrowser browserService) : base(list, browserService)
        {
        }

        protected override string GetAssetTextIdentifier(RoomItem item) => $"{item.RoomNumber} - {item.RoomType}";
    }
}