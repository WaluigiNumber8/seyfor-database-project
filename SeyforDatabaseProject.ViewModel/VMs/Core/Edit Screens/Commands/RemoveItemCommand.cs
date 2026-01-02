using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public class RemoveItemCommand<TItem, TItemVM> : AsyncCommandBase
        where TItem : DatabaseItemBase<TItem>
        where TItemVM : DatabaseItemVMBase<TItem>
    {
        private readonly ScreenEditingVMBase<TItem, TItemVM> _vm;
        private readonly DatabaseItemList<TItem> _itemList;
        private readonly Action _navigateToListing;

        public RemoveItemCommand(ScreenEditingVMBase<TItem, TItemVM> vm, DatabaseItemList<TItem> itemList, Action navigateToListing)
        {
            _vm = vm;
            _navigateToListing = navigateToListing;
            _itemList = itemList;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                Console.WriteLine($"Try remove {typeof(TItem)}.");
                await _itemList.Remove(_vm.CurrentItem!.ID);

                _navigateToListing.Invoke();
            }
            catch (DataConflictException)
            {
                Console.WriteLine("Due to conflicts, could not remove equipment.");
                throw;
            }
            catch (Exception)
            {
                Console.WriteLine("An unknown error was thrown. Could not remove equipment.");
                throw;
            }
        }
    }
}