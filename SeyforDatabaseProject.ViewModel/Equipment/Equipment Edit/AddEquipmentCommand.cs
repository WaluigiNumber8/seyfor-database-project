using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    /// <summary>
    /// Command for adding new equipment to database.
    /// </summary>
    public class AddEquipmentCommand : AsyncCommandBase
    {
        private readonly EquipmentEditVM _vm;
        private readonly Hotel _hotel;
        private readonly NavigationService<EquipmentTableVM> _equipmentListingNavigationService;

        public AddEquipmentCommand(EquipmentEditVM vm, Hotel hotel, NavigationService<EquipmentTableVM> equipmentListingNavigationService)
        {
            _vm = vm;
            _hotel = hotel;
            _equipmentListingNavigationService = equipmentListingNavigationService;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                EquipmentItem newEquipment = new()
                {
                    Title = _vm.Title,
                    Description = _vm.Description
                };
                await _hotel.Equipment.AddNew(newEquipment);
                
                _equipmentListingNavigationService.Navigate();
            }
            catch (DataConflictException)
            {
                Console.WriteLine("Due to conflicts, could not create equipment.");
            }
            catch (Exception)
            {
                Console.WriteLine("An unknown error was thrown. Could not create equipment.");
            }
        }
    }
}