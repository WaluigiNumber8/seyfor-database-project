using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public class RemoveItemCommand<TItem, TItemVM> : AsyncCommandBase where TItem : DatabaseItemBase<TItem> where TItemVM : DatabaseItemVMBase<TItem>
    {
        private readonly ScreenEditVMBase<TItem, TItemVM> _vm;
        private readonly DatabaseItemList<TItem> _itemList;
        private readonly NavigationService<ScreenListingVMBase<TItem, TItemVM>> _listingNavigationService;

        public RemoveItemCommand(ScreenEditVMBase<TItem, TItemVM> vm, DatabaseItemList<TItem> itemList, NavigationService<ScreenListingVMBase<TItem, TItemVM>> listingNavigationService)
        {
            _vm = vm;
            _listingNavigationService = listingNavigationService;
            _itemList = itemList;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                Console.WriteLine($"Try remove {typeof(TItem)}.");
                await _itemList.Remove(_vm.CurrentItem!.ID);

                _listingNavigationService.Navigate();
            }
            catch (DataConflictException)
            {
                Console.WriteLine("Due to conflicts, could not remove equipment.");
            }
            catch (Exception)
            {
                Console.WriteLine("An unknown error was thrown. Could not remove equipment.");
                throw;
            }
        }
    }
}