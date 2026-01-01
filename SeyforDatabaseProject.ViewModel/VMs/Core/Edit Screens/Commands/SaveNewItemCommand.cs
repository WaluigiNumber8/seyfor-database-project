using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    /// <summary>
    /// Command for adding new equipment to database.
    /// </summary>
    public class SaveNewItemCommand<TItem, TItemVM> : AsyncCommandBase where TItem : DatabaseItemBase<TItem> where TItemVM : DatabaseItemVMBase<TItem>
    {
        private readonly Func<TItem> _createItemFromFields;
        private readonly DatabaseItemList<TItem> _itemList;
        private readonly NavigationService<ScreenListingVMBase<TItem,TItemVM>> _listingNavigationService;

        public SaveNewItemCommand(Func<TItem> createItemFromFields, DatabaseItemList<TItem> itemList, NavigationService<ScreenListingVMBase<TItem,TItemVM>> listingNavigationService)
        {
            _listingNavigationService = listingNavigationService;
            _createItemFromFields = createItemFromFields;
            _itemList = itemList;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                TItem item = _createItemFromFields();
                Console.WriteLine("Try add new equipment");
                await _itemList.AddNew(item);

                _listingNavigationService.Navigate();
            }
            catch (DataConflictException)
            {
                Console.WriteLine($"Due to conflicts, could not create item of type {typeof(TItem)}.");
            }
            catch (Exception)
            {
                Console.WriteLine($"An unknown error was thrown. Could not create item of type {typeof(TItem)}.");
                throw;
            }
        }
    }
}