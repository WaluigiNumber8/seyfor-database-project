using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public class GoToAddItemScreenCommand<TItem, TItemVM> : CommandBase 
        where TItem : DatabaseItemBase<TItem> 
        where TItemVM : DatabaseItemVMBase<TItem> 
    {
        private readonly Action _navigateToEdit;
        private readonly ScreenEditingVMBase<TItem, TItemVM> _targetVM;

        public GoToAddItemScreenCommand(ScreenEditingVMBase<TItem, TItemVM> targetVM, Action navigateToEdit)
        {
            _navigateToEdit = navigateToEdit;
            _targetVM = targetVM;
        }

        public override void Execute(object? parameter)
        {
            _navigateToEdit.Invoke();
            _targetVM.LoadForAdd();
        }
    }
}