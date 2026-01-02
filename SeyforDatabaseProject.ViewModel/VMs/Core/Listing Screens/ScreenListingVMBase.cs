using System.Collections.ObjectModel;
using System.Windows.Input;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Equipment;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public abstract class ScreenListingVMBase<TItem, TItemVM> : ViewModelBase
        where TItem : DatabaseItemBase<TItem>
        where TItemVM : DatabaseItemVMBase<TItem>
    {
        public ScreenListingVMBase(DatabaseItemList<TItem> list, ScreenEditingVMBase<TItem, TItemVM> editVM, Action navigateToEdit)
        {
            AddEntryCommand = new GoToAddItemScreenCommand<TItem, TItemVM>(editVM, navigateToEdit);
            EditEntryCommand = new GoToUpdateItemScreenCommand<TItem, TItemVM>(editVM, navigateToEdit);
            RefreshEntriesCommand = new RefreshEntriesCommand<TItem, TItemVM>(this, list);
        }

        public ICommand AddEntryCommand { get; }
        public ICommand EditEntryCommand { get; }
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