using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Rooms;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    /// <summary>
    /// Refreshes the equipment entries in the ViewModel.
    /// </summary>
    public class RefreshEntriesCommand<TItem, TItemVM> : AsyncCommandBase where TItem : DatabaseItemBase<TItem> where TItemVM : DatabaseItemVMBase<TItem>
    {
        private readonly ScreenListingVMBase<TItem, TItemVM> _vm;
        private readonly DatabaseItemList<TItem> _list;

        public RefreshEntriesCommand(ScreenListingVMBase<TItem, TItemVM> vm, DatabaseItemList<TItem> list)
        {
            _vm = vm;
            _list = list;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _list.Load();
                _vm.UpdateEntries(_list.Items);
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while refreshing equipment entries.");
                throw;
            }
        }
    }
}