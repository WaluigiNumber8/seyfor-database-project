using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.ContentBrowser
{
    /// <summary>
    /// Calls to select an asset from a content browser.
    /// </summary>
    public class OpenContentBrowserForGuestsCommand : CommandBase
    {
        private readonly Action<GuestItem> _selectAssetAction;
        private readonly IServiceContentBrowser _contentBrowserService;
        private readonly HotelStore _hotelStore;

        public OpenContentBrowserForGuestsCommand(HotelStore hotelStore, Action<GuestItem> selectAssetAction, IServiceContentBrowser contentBrowserService)
        {
            _hotelStore = hotelStore;
            _selectAssetAction = selectAssetAction;
            _contentBrowserService = contentBrowserService;
        }

        public override void Execute(object? parameter)
        {
            //Open asset picker window
            ContentBrowserVMBase<GuestItem> browser = new ContentBrowserGuestVM(_hotelStore);
            browser.RefreshEntriesCommand.Execute(null);
            browser.WhenConfirm = _selectAssetAction;
            _contentBrowserService.Open(browser);

            //Call method when window closed.
        }
    }
}