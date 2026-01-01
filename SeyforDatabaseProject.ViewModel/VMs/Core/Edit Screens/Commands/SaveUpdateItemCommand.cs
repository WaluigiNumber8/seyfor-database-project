using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public class SaveUpdateItemCommand<TItem, TItemVM, TListingVM, TEditVM> : AsyncCommandBase
        where TItem : DatabaseItemBase<TItem>
        where TItemVM : DatabaseItemVMBase<TItem>
        where TListingVM : ViewModelBase
        where TEditVM : ViewModelBase
    {
        private readonly Func<int, TItem> _createItemFromFields;
        private readonly DatabaseItemList<TItem> _itemList;
        private readonly ScreenEditVMBase<TItem, TItemVM, TListingVM, TEditVM> _vm;
        private readonly NavigationService<TListingVM> _navigateToListing;

        public SaveUpdateItemCommand(Func<int, TItem> createItemFromFields, ScreenEditVMBase<TItem, TItemVM, TListingVM, TEditVM> vm, DatabaseItemList<TItem> itemList, NavigationService<TListingVM> navigateToListing)
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