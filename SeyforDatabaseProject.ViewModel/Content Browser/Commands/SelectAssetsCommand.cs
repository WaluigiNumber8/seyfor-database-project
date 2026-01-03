using System.Collections;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    public class SelectAssetsCommand<TAssetType> : CommandBase where TAssetType : DatabaseItemBase<TAssetType>
    {
        private readonly ContentBrowserVMBase<TAssetType> _browserVM;
        private readonly DatabaseItemList<TAssetType> _items;
        private readonly IServiceContentBrowser _browserService;

        public SelectAssetsCommand(ContentBrowserVMBase<TAssetType> browserVm, DatabaseItemList<TAssetType> items, IServiceContentBrowser browserService)
        {
            _browserVM = browserVm;
            _items = items;
            _browserService = browserService;
        }
        
        public override void Execute(object? parameter)
        {
            if (parameter is not IList items)
            {
                throw new InvalidOperationException("No data was selected.");
            }

            List<TAssetType> finalItems = new();
            foreach (object selectedItem in items)
            {
                if (selectedItem is not ContentBrowserItemVM item) throw new InvalidOperationException($"Selected item is in invalid format. Must be {typeof(TAssetType)}.");
                
                foreach (TAssetType i in _items.Items)
                {
                    if (i.ID != item.ID) continue;
                    finalItems.Add(i);
                }
            }

            if (finalItems.Count > 0)
            {
                _browserVM.WhenConfirm.Invoke(finalItems);
                _browserService.Close();
                return;
            }
            
            throw new InvalidOperationException($"{nameof(finalItems)} cannot be empty.");
        }
    }
}