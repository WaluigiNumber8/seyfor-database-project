using System.Collections.ObjectModel;
using System.Windows.Input;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Equipment;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public abstract class ScreenListingVMBase<TItem, TItemVM, TListingVM, TEditVM> : ViewModelBase
        where TItem : DatabaseItemBase<TItem>
        where TItemVM : DatabaseItemVMBase<TItem>
        where TListingVM : ViewModelBase
        where TEditVM : ViewModelBase
    {
        public ScreenListingVMBase(DatabaseItemList<TItem> list, ScreenEditVMBase<TItem, TItemVM, TListingVM, TEditVM> editVM, NavigationService<TEditVM> navigateToEdit)
        {
            AddEntryCommand = new GoToAddItemScreenCommand<TItem, TItemVM, TListingVM, TEditVM>(editVM, navigateToEdit);
            EditEntryCommand = new GoToUpdateItemScreenCommand<TItem, TItemVM, TListingVM, TEditVM>(editVM, navigateToEdit);
            RefreshEntriesCommand = new RefreshEntriesCommand<TItem, TItemVM, TListingVM, TEditVM>(this, list);
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