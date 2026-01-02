using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.ViewModel.Core
{
    /// <summary>
    /// Represents a screen on which the user can list and edit database items. <br/>
    /// Allows navigating between listing and editing views.
    /// </summary>
    public abstract class ScreenItemOperationsBase<TItem, TItemVM, TListingScreen, TEditingScreen> : ViewModelBase 
        where TItem : DatabaseItemBase<TItem> 
        where TItemVM : DatabaseItemVMBase<TItem>
        where TListingScreen : ScreenListingVMBase<TItem, TItemVM>
        where TEditingScreen : ScreenEditingVMBase<TItem, TItemVM>
    {
        protected TListingScreen ListingVM { get; private set; }
        protected TEditingScreen EditingVM { get; private set; }
        
        private ViewModelBase _currentOperationVm;
        public ViewModelBase CurrentOperationVM
        {
            get => _currentOperationVm;
            protected set
            {
                _currentOperationVm = value;
                OnPropertyChanged();
            }
        }

        public void Construct()
        {
            EditingVM = CreateEditingScreen.Invoke();
            ListingVM = CreateListingScreen.Invoke();
        }
        
        public void NavigateToListing()
        {
            ListingVM.RefreshEntriesCommand.Execute(null);
            CurrentOperationVM = ListingVM;
        }

        public void NavigateToEditing()
        {
            CurrentOperationVM = EditingVM;
        }

        protected abstract Func<TListingScreen> CreateListingScreen { get; }
        protected abstract Func<TEditingScreen> CreateEditingScreen { get; }
    }
}