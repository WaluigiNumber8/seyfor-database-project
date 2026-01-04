using System.Collections;
using System.ComponentModel;
using System.Windows.Input;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Validation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public abstract class ScreenEditingVMBase<TItem, TItemVM> : ViewModelBase, INotifyDataErrorInfo
        where TItem : DatabaseItemBase<TItem>
        where TItemVM : DatabaseItemVMBase<TItem>
    {
        public event EventHandler<DataErrorsChangedEventArgs>? ErrorsChanged;

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

        private bool _isSaveButtonEnabled;

        public bool IsSaveButtonEnabled
        {
            get => _isSaveButtonEnabled;
            set
            {
                _isSaveButtonEnabled = value;
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

        protected readonly VMValidationHandler _errors;
        public TItemVM? CurrentItem { get; private set; }
        protected abstract string ItemTypeName { get; }

        /// <summary>
        /// Creates a TItem from the current fields in the ViewModel. Takes the ID as an argument.
        /// </summary>
        protected abstract Func<int, TItem> CreateItemFromFields { get; }

        public ScreenEditingVMBase(DatabaseItemList<TItem> itemList, Action navigateToListing)
        {
            _saveNewItemCommand = new SaveNewItemCommand<TItem>(CreateItemFromFields, itemList, navigateToListing);
            _saveUpdateItemCommand = new SaveUpdateItemCommand<TItem, TItemVM>(CreateItemFromFields, this, itemList, navigateToListing);
            SaveCommand = _saveNewItemCommand;
            CancelCommand = new CancelChangesCommand(navigateToListing);
            RemoveCommand = new RemoveItemCommand<TItem, TItemVM>(this, itemList, navigateToListing);
            
            _errors = new VMValidationHandler();
            _errors.ErrorsChanged += WhenErrorsChange;
        }

        public override void Dispose()
        {
            _errors.ErrorsChanged -= WhenErrorsChange;
            base.Dispose();
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


        public bool HasErrors
        {
            get => _errors.HasErrors;
        }

        public IEnumerable GetErrors(string? propertyName) => _errors.GetErrors(propertyName);

        private void WhenErrorsChange(object? sender, DataErrorsChangedEventArgs e)
        {
            ErrorsChanged?.Invoke(sender, e);
            IsSaveButtonEnabled = !_errors.HasErrors;
        }
    }
}