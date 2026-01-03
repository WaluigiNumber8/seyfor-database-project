using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    public class ContentBrowserEquipmentVM : ContentBrowserVMBase<EquipmentItem>
    {
        public ContentBrowserEquipmentVM(DatabaseItemList<EquipmentItem> list, IServiceContentBrowser browserService) : base(list, browserService)
        {
        }

        protected override string GetAssetTextIdentifier(EquipmentItem item) => $"{item.Title} - {item.Description}";

        protected override string AssetTypeInString { get => "Equipment"; }
    }
}