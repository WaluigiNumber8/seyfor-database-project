using System.Collections.ObjectModel;
using System.Windows.Input;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Equipment;

namespace SeyforDatabaseProject.ViewModel.Rooms
{
    public abstract class DatabaseListingScreenBase<TItem, TItemVM> : ViewModelBase where TItem : DatabaseItemBase<TItem> where TItemVM : ViewModelBase
    {
        public DatabaseListingScreenBase(HotelStore hotelStore, DatabaseItemList<TItem> list)
        {
            RefreshEntriesCommand = new RefreshEntriesCommand<TItem, TItemVM>(hotelStore, this, list);
        }

        public ICommand RefreshEntriesCommand { get; }

        public void UpdateEntries(IEnumerable<TItem> allItems)
        {
            Console.WriteLine($"Updating {typeof(TItem)} entries...");
            Items.Clear();
            foreach (TItem item in allItems)
            {
                Items.Add(CreateNewItemVM(item));
            }
        }
        
        protected abstract ObservableCollection<TItemVM> Items { get; }
        protected abstract Func<TItem, TItemVM> CreateNewItemVM { get; }
    }
}