using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    public interface IViewModelWithList<TAssetType> where TAssetType : DatabaseItemBase<TAssetType>
    {
        void UpdateEntries(IEnumerable<TAssetType> items);
    }
}