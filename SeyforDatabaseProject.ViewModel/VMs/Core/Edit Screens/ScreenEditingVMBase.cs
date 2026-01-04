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
        private readonly IDictionary<string, IList<ValidationRule>> _validationRules;

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
            _validationRules = new Dictionary<string, IList<ValidationRule>>();
            ConstructValidationRules();
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

        /// <summary>
        /// Add property validation rules to the list. Make sure to call <b>CheckValidations()</b> in the property setters.
        /// </summary>
        /// <param name="validationRules">The list validation rules that will get checked.</param>
        protected abstract void AddValidationRules(IList<ValidationRule> validationRules);
        
        private void ConstructValidationRules()
        {
            IList<ValidationRule> rules = new List<ValidationRule>();
            AddValidationRules(rules);
            foreach (ValidationRule rule in rules)
            {
                if (!_validationRules.ContainsKey(rule.PropertyName))
                {
                    _validationRules.Add(rule.PropertyName, new List<ValidationRule>());
                }
                _validationRules[rule.PropertyName].Add(rule);
            }
        }
        
        protected void CheckValidations(string propertyName)
        {
            _errors.ClearErrors(propertyName);
            if (!_validationRules.TryGetValue(propertyName, out IList<ValidationRule>? rules)) return;
            if (rules.Count == 0) return;
            foreach (ValidationRule rule in rules)
            {
                bool passed = !rule.IsWrong();
                if (!passed) _errors.AddError(propertyName, rule.Message);
            }
            
        }
        
        #region Errors

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

        #endregion
    }
}