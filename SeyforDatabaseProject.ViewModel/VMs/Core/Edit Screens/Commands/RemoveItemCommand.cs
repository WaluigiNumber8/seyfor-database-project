using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public class RemoveItemCommand<TItem, TItemVM, TListingVM, TEditVM> : AsyncCommandBase
        where TItem : DatabaseItemBase<TItem>
        where TItemVM : DatabaseItemVMBase<TItem>
        where TListingVM : ViewModelBase
        where TEditVM : ViewModelBase
    {
        private readonly ScreenEditVMBase<TItem, TItemVM, TListingVM, TEditVM> _vm;
        private readonly DatabaseItemList<TItem> _itemList;
        private readonly NavigationService<TListingVM> _navigateToListing;

        public RemoveItemCommand(ScreenEditVMBase<TItem, TItemVM, TListingVM, TEditVM> vm, DatabaseItemList<TItem> itemList, NavigationService<TListingVM> navigateToListing)
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

                _navigateToListing.Navigate();
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