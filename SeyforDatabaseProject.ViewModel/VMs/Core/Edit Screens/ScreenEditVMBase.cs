using System.Windows.Input;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public abstract class ScreenEditVMBase<TItem, TItemVM, TListingVM, TEditVM> : ViewModelBase
        where TItem : DatabaseItemBase<TItem>
        where TItemVM : DatabaseItemVMBase<TItem>
        where TListingVM : ViewModelBase
        where TEditVM : ViewModelBase
    {
        #region Properties

        private string _headerText;

        public string HeaderText
        {
            get => _headerText;
            set
            {
                _headerText = value;
                OnPropertyChanged();
            }
        }

        private string _saveButtonText;

        public string SaveButtonText
        {
            get => _saveButtonText;
            set
            {
                _saveButtonText = value;
                OnPropertyChanged();
            }
        }

        private bool _showRemoveButton;

        public bool ShowRemoveButton
        {
            get => _showRemoveButton;
            set
            {
                _showRemoveButton = value;
                OnPropertyChanged();
            }
        }

        #endregion

        public ICommand SaveCommand { get; private set; }
        public ICommand CancelCommand { get; }
        public ICommand RemoveCommand { get; }
        private readonly ICommand _saveUpdateItemCommand;
        private readonly ICommand _saveNewItemCommand;

        public TItemVM? CurrentItem { get; private set; }
        protected abstract string ItemTypeName { get; }
        
        /// <summary>
        /// Creates a TItem from the current fields in the ViewModel. Takes the ID as an argument.
        /// </summary>
        protected abstract Func<int, TItem> CreateItemFromFields { get; }

        public ScreenEditVMBase(DatabaseItemList<TItem> itemList, NavigationService<TListingVM> navigateToListing)
        {
            _saveNewItemCommand = new SaveNewItemCommand<TItem, TItemVM, TListingVM>(CreateItemFromFields, itemList, navigateToListing);
            _saveUpdateItemCommand = new SaveUpdateItemCommand<TItem, TItemVM, TListingVM, TEditVM>(CreateItemFromFields, this, itemList, navigateToListing);
            SaveCommand = _saveNewItemCommand;
            CancelCommand = new NavigateCommand(navigateToListing);
            RemoveCommand = new RemoveItemCommand<TItem, TItemVM, TListingVM, TEditVM>(this, itemList, navigateToListing);
        }

        public void LoadForEdit(TItemVM? item)
        {
            CurrentItem = item;
            if (CurrentItem == null)
            {
                ClearFields();
                return;
            }

            HeaderText = $"Editing {ItemTypeName}";
            SaveButtonText = "Save";

            SetPropertiesFromItem(CurrentItem);

            SaveCommand = _saveUpdateItemCommand;
            ShowRemoveButton = true;
        }

        public void LoadForAdd()
        {
            CurrentItem = null;
            HeaderText = $"Adding New {ItemTypeName}";
            SaveButtonText = "Add";
            ClearFields();

            SaveCommand = _saveNewItemCommand;
            ShowRemoveButton = false;
        }

        public abstract void ClearFields();

        protected abstract void SetPropertiesFromItem(TItemVM item);
    }
}