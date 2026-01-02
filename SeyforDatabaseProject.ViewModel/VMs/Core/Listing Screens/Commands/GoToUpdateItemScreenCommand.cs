using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public class GoToUpdateItemScreenCommand<TItem, TItemVM> : CommandBase
        where TItem : DatabaseItemBase<TItem>
        where TItemVM : DatabaseItemVMBase<TItem>
    {
        private readonly ScreenEditingVMBase<TItem, TItemVM> _targetVM;
        private readonly Action _navigateToEdit;

        public GoToUpdateItemScreenCommand(ScreenEditingVMBase<TItem, TItemVM> targetVM, Action navigateToEdit)
        {
            _targetVM = targetVM;
            _navigateToEdit = navigateToEdit;
        }

        public override void Execute(object? parameter)
        {
            _navigateToEdit.Invoke();
            TItemVM? selectedEquipment = parameter as TItemVM;
            _targetVM.LoadForEdit(selectedEquipment);
        }
    }
}