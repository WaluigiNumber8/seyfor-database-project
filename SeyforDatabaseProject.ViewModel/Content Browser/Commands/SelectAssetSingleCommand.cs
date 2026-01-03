using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    public class SelectAssetSingleCommand<TAssetType> : CommandBase where TAssetType : DatabaseItemBase<TAssetType>
    {
        private readonly ContentBrowserVMBase<TAssetType> _browserVM;
        private readonly DatabaseItemList<TAssetType> _items;

        public SelectAssetSingleCommand(ContentBrowserVMBase<TAssetType> browserVm, DatabaseItemList<TAssetType> items)
        {
            _browserVM = browserVm;
            _items = items;
        }

        public override void Execute(object? parameter)
        {
            ContentBrowserItemVM? item = parameter as ContentBrowserItemVM;
            if (item == null)
            {
                throw new InvalidOperationException("No data was selected.");
            }

            Console.WriteLine($"Item: {item}");
            foreach (TAssetType i in _items.Items)
            {
                if (i.ID != item.ID) continue;
                
                _browserVM.WhenConfirm.Invoke(i);
                return;
            }
            throw new InvalidOperationException($"Could not find the item '{item}' in {_items}");
        }
    }
}