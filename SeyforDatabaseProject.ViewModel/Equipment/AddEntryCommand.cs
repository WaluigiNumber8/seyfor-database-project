using System.Windows.Input;
using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel
{
    public class AddEntryCommand : AsyncCommandBase
    {
        private readonly Hotel _hotel;
        private readonly EquipmentVM _equipmentVM;

        public AddEntryCommand(Hotel hotel, EquipmentVM equipmentVm)
        {
            _hotel = hotel;
            _equipmentVM = equipmentVm;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            Equipment testEquipment = new()
            {
                Title = "Test Equipment",
                Description = "Test Test Test Test Test Test Test Test Test."
            };

            try
            {
                await _hotel.Equipment.AddNew(testEquipment);
            }
            catch (DataConflictException)
            {
                Console.WriteLine("Due to conflicts, could not create equipment.");
            }
            catch (Exception)
            {
                Console.WriteLine("An unknown error was thrown. Could not create equipment.");
            }
            _equipmentVM.RefreshEntriesCommand.Execute(null);
        }
    }
}