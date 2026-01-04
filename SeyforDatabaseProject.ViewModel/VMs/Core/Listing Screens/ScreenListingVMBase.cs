using System.Collections.ObjectModel;
using System.Windows.Input;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.ContentBrowser;
using SeyforDatabaseProject.ViewModel.Equipment;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public abstract class ScreenListingVMBase<TItem, TItemVM> : ViewModelBase, IViewModelWithList<TItem>
        where TItem : DatabaseItemBase<TItem>
        where TItemVM : DatabaseItemVMBase<TItem>
    {
        #region Properties

        private ObservableCollection<TItemVM> _items;

        public ObservableCollection<TItemVM> Items
        {
            get { return _items; }
            set { _items = value; }
        }

        #endregion

        #region Commands

        public ICommand AddEntryCommand { get; }
        public ICommand EditEntryCommand { get; }
        public ICommand RefreshEntriesCommand { get; }

        #endregion

        public ScreenListingVMBase(DatabaseItemList<TItem> list, ScreenEditingVMBase<TItem, TItemVM> editVM, Action navigateToEdit)
        {
            Items = new ObservableCollection<TItemVM>();
            AddEntryCommand = new GoToAddItemScreenCommand<TItem, TItemVM>(editVM, navigateToEdit);
            EditEntryCommand = new GoToUpdateItemScreenCommand<TItem, TItemVM>(editVM, navigateToEdit);
            RefreshEntriesCommand = new RefreshEntriesCommand<TItem>(this, list);
        }

        public void UpdateEntries(IEnumerable<TItem> allItems)
        {
            Items.Clear();
            foreach (TItem item in allItems)
            {
                Items.Add(CreateNewItemVM(item));
            }
        }

        protected abstract Func<TItem, TItemVM> CreateNewItemVM { get; }
    }
}