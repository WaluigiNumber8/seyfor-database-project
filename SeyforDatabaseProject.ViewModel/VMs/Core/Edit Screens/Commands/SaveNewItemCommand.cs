using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    /// <summary>
    /// Command for adding new equipment to database.
    /// </summary>
    public class SaveNewItemCommand<TItem, TItemVM, TListingVM> : AsyncCommandBase 
        where TItem : DatabaseItemBase<TItem> 
        where TItemVM : DatabaseItemVMBase<TItem>
        where TListingVM : ViewModelBase
    {
        private readonly Func<TItem> _createItemFromFields;
        private readonly DatabaseItemList<TItem> _itemList;
        private readonly NavigationService<TListingVM> _navigateToListing;

        public SaveNewItemCommand(Func<TItem> createItemFromFields, DatabaseItemList<TItem> itemList, NavigationService<TListingVM> navigateToListing)
        {
            _navigateToListing = navigateToListing;
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

                _navigateToListing.Navigate();
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