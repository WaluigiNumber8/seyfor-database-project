using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel
{
    /// <summary>
    /// Refreshes the equipment entries in the ViewModel.
    /// </summary>
    public class RefreshEquipmentEntriesCommand : AsyncCommandBase
    {
        private readonly Hotel _hotel;
        private readonly EquipmentVM _equipmentVM;

        public RefreshEquipmentEntriesCommand(Hotel hotel, EquipmentVM equipmentVM)
        {
            _hotel = hotel;
            _equipmentVM = equipmentVM;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                IEnumerable<Equipment> allEquipment = await _hotel.Equipment.GetAll();
                _equipmentVM.UpdateEntries(allEquipment);
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while refreshing equipment entries.");
                throw;
            }
        }
    }
}