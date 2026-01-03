using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    public class SelectAssetSingleCommand<TAssetType> : CommandBase where TAssetType : DatabaseItemBase<TAssetType>
    {
        private readonly ContentBrowserVMBase<TAssetType> _browserVM;
        private readonly DatabaseItemList<TAssetType> _items;
        private readonly IServiceContentBrowser _browserService;

        public SelectAssetSingleCommand(ContentBrowserVMBase<TAssetType> browserVm, DatabaseItemList<TAssetType> items, IServiceContentBrowser browserService)
        {
            _browserVM = browserVm;
            _items = items;
            _browserService = browserService;
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
                _browserService.Close();
                return;
            }
            throw new InvalidOperationException($"Could not find the item '{item}' in {_items}");
        }
    }
}