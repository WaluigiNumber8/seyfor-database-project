using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    /// <summary>
    /// Command for adding new equipment to database.
    /// </summary>
    public class AddEquipmentCommand : AsyncCommandBase
    {
        private readonly EquipmentEditVM _vm;
        private readonly Hotel _hotel;

        public AddEquipmentCommand(EquipmentEditVM vm, Hotel hotel)
        {
            _vm = vm;
            _hotel = hotel;
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
                
                //TODO: Add navigation to listing.
                
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