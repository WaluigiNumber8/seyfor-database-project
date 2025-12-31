using System;
using System.Threading.Tasks;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    /// <summary>
    /// Refreshes the equipment entries in the ViewModel.
    /// </summary>
    public class RefreshEquipmentEntriesCommand : AsyncCommandBase
    {
        private readonly HotelStore _hotelStore;
        private readonly EquipmentListingVM _equipmentVM;

        public RefreshEquipmentEntriesCommand(HotelStore hotelStore, EquipmentListingVM equipmentVM)
        {
            _hotelStore = hotelStore;
            _equipmentVM = equipmentVM;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                await _hotelStore.Equipment.Load();
                _equipmentVM.UpdateEntries(_hotelStore.Equipment.Items);
            }
            catch (Exception)
            {
                Console.WriteLine("An error occurred while refreshing equipment entries.");
                throw;
            }
        }
    }
}