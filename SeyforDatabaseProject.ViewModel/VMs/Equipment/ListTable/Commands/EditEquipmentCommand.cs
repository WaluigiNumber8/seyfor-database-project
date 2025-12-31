using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class EditEquipmentCommand : CommandBase
    {
        private readonly EquipmentEditVM _editVM;
        private readonly NavigationService<EquipmentEditVM> _navigation;

        public EditEquipmentCommand(EquipmentEditVM equipmentEditVM, NavigationService<EquipmentEditVM> navigation)
        {
            _editVM = equipmentEditVM;
            _navigation = navigation;
        }
        
        public override void Execute(object? parameter)
        {
            _navigation.Navigate();
            EquipmentItemVM? selectedEquipment = parameter as EquipmentItemVM;
            _editVM.LoadForEdit(selectedEquipment);
        }
    }
}