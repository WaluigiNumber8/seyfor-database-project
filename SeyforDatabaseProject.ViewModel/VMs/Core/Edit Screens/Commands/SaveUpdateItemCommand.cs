using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public class SaveUpdateItemCommand<TItem, TItemVM> : AsyncCommandBase
        where TItem : DatabaseItemBase<TItem>
        where TItemVM : DatabaseItemVMBase<TItem>
    {
        private readonly Func<int, TItem> _createItemFromFields;
        private readonly DatabaseItemList<TItem> _itemList;
        private readonly ScreenEditingVMBase<TItem, TItemVM> _vm;
        private readonly Action _navigateToListing;

        public SaveUpdateItemCommand(Func<int, TItem> createItemFromFields, ScreenEditingVMBase<TItem, TItemVM> vm, DatabaseItemList<TItem> itemList, Action navigateToListing)
        {
            _createItemFromFields = createItemFromFields;
            _itemList = itemList;
            _navigateToListing = navigateToListing;
            _vm = vm;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                TItem item = _createItemFromFields(_vm.CurrentItem!.ID);
                Console.WriteLine($"Try update {typeof(TItem)}.");
                await _itemList.Update(item);

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