using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public class GoToAddItemScreenCommand<TItem, TItemVM, TListingVM, TEditVM> : CommandBase 
        where TItem : DatabaseItemBase<TItem> 
        where TItemVM : DatabaseItemVMBase<TItem> 
        where TListingVM : ViewModelBase
        where TEditVM : ViewModelBase
    {
        private readonly NavigationService<TEditVM> _navigateToEdit;
        private readonly ScreenEditVMBase<TItem, TItemVM, TListingVM, TEditVM> _targetVM;

        public GoToAddItemScreenCommand(ScreenEditVMBase<TItem, TItemVM, TListingVM, TEditVM> targetVM, NavigationService<TEditVM> navigateToEdit)
        {
            _navigateToEdit = navigateToEdit;
            _targetVM = targetVM;
        }

        public override void Execute(object? parameter)
        {
            _navigateToEdit.Navigate();
            _targetVM.LoadForAdd();
        }
    }
}