using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Core
{
    public class GoToUpdateItemScreenCommand<TItem, TItemVM> : CommandBase where TItem : DatabaseItemBase<TItem> where TItemVM : DatabaseItemVMBase<TItem>
    {
        private readonly ScreenEditVMBase<TItem, TItemVM> _targetVM;
        private readonly NavigationService<ScreenEditVMBase<TItem, TItemVM>> _navigateToEdit;

        public GoToUpdateItemScreenCommand(ScreenEditVMBase<TItem, TItemVM> targetVM, NavigationService<ScreenEditVMBase<TItem, TItemVM>> navigateToEdit)
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