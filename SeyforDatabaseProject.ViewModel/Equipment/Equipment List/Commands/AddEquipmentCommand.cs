using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class AddEquipmentCommand : CommandBase
    {
        private readonly NavigationService<EquipmentEditVM> _navigateToEditEquipment;
        private readonly EquipmentEditVM _equipmentVM;

        public AddEquipmentCommand(NavigationService<EquipmentEditVM> navigateToEditEquipment, EquipmentEditVM equipmentVm)
        {
            _navigateToEditEquipment = navigateToEditEquipment;
            _equipmentVM = equipmentVm;
        }

        public override void Execute(object? parameter)
        {
            _navigateToEditEquipment.Navigate();
            _equipmentVM.ClearFields();
        }
    }
}