using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public class GoToAddItemScreenCommand<TItem, TItemVM> : CommandBase where TItem : DatabaseItemBase<TItem> where TItemVM : DatabaseItemVMBase<TItem>
    {
        private readonly NavigationService<ScreenEditVMBase<TItem, TItemVM>> _navigateToEdit;
        private readonly ScreenEditVMBase<TItem, TItemVM> _targetVM;

        public GoToAddItemScreenCommand(ScreenEditVMBase<TItem, TItemVM> targetVM, NavigationService<ScreenEditVMBase<TItem, TItemVM>> navigateToEdit)
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