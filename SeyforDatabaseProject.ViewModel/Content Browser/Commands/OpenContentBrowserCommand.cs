using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    public class OpenContentBrowserCommand<TItemType> : CommandBase where TItemType : DatabaseItemBase<TItemType>
    {
        private readonly Action<IList<TItemType>> _selectAssetAction;
        private readonly Func<ContentBrowserVMBase<TItemType>> _createBrowserVM;
        private readonly IServiceContentBrowser _contentBrowserService;

        public OpenContentBrowserCommand(Action<IList<TItemType>> selectAssetAction, Func<ContentBrowserVMBase<TItemType>> createBrowserVm, IServiceContentBrowser contentBrowserService)
        {
            _selectAssetAction = selectAssetAction;
            _contentBrowserService = contentBrowserService;
            _createBrowserVM = createBrowserVm;
        }

        public override void Execute(object? parameter)
        {
            ContentBrowserVMBase<TItemType> browser = _createBrowserVM();
            browser.RefreshEntriesCommand.Execute(null);
            browser.WhenConfirm = _selectAssetAction;
            _contentBrowserService.Open(browser);
        }
    }
}