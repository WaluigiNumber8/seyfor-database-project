using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    /// <summary>
    /// Command for adding new equipment to database.
    /// </summary>
    public class SaveNewItemCommand<TItem> : AsyncCommandBase 
        where TItem : DatabaseItemBase<TItem>
    {
        private readonly Func<int, TItem> _createItemFromFields;
        private readonly DatabaseItemList<TItem> _itemList;
        private readonly Action _navigateToListing;

        public SaveNewItemCommand(Func<int, TItem> createItemFromFields, DatabaseItemList<TItem> itemList, Action navigateToListing)
        {
            _navigateToListing = navigateToListing;
            _createItemFromFields = createItemFromFields;
            _itemList = itemList;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                int highest = _itemList.Items.Max(i => i.ID);
                TItem item = _createItemFromFields(highest + 1);
                Console.WriteLine($"Try add new {typeof(TItem)}");
                await _itemList.AddNew(item);

                _navigateToListing.Invoke();
            }
            catch (DataConflictException)
            {
                Console.WriteLine($"Due to conflicts, could not create item of type {typeof(TItem)}.");
                throw;
            }
            catch (Exception)
            {
                Console.WriteLine($"An unknown error was thrown. Could not create item of type {typeof(TItem)}.");
                throw;
            }
        }
    }
}