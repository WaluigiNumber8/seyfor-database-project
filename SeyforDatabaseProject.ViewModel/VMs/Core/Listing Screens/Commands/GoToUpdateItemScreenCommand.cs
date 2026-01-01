using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public class GoToUpdateItemScreenCommand<TItem, TItemVM, TListingVM, TEditVM> : CommandBase
        where TItem : DatabaseItemBase<TItem>
        where TItemVM : DatabaseItemVMBase<TItem>
        where TListingVM : ViewModelBase
        where TEditVM : ViewModelBase
    {
        private readonly ScreenEditVMBase<TItem, TItemVM, TListingVM, TEditVM> _targetVM;
        private readonly NavigationService<TEditVM> _navigateToEdit;

        public GoToUpdateItemScreenCommand(ScreenEditVMBase<TItem, TItemVM, TListingVM, TEditVM> targetVM, NavigationService<TEditVM> navigateToEdit)
        {
            _targetVM = targetVM;
            _navigateToEdit = navigateToEdit;
        }

        public override void Execute(object? parameter)
        {
            _navigateToEdit.Navigate();
            TItemVM? selectedEquipment = parameter as TItemVM;
            _targetVM.LoadForEdit(selectedEquipment);
        }
    }
}