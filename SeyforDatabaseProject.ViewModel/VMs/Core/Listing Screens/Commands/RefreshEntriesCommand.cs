using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.ContentBrowser;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    /// <summary>
    /// Refreshes the equipment entries in the ViewModel.
    /// </summary>
    public class RefreshEntriesCommand<TItem> : AsyncCommandBase 
        where TItem : DatabaseItemBase<TItem>
    {
        private readonly IViewModelWithList<TItem> _vm;
        private readonly DatabaseItemList<TItem> _list;

        public RefreshEntriesCommand(IViewModelWithList<TItem> vm, DatabaseItemList<TItem> list)
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