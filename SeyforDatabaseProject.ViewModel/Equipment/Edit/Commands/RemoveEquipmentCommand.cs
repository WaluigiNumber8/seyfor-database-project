using System;
using System.Threading.Tasks;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class RemoveEquipmentCommand : AsyncCommandBase
    {
        private readonly HotelStore _hotelStore;
        private readonly EquipmentEditVM _vm;
        private readonly NavigationService<EquipmentListingVM> _equipmentListingNavigationService;

        public RemoveEquipmentCommand(EquipmentEditVM vm, HotelStore hotelStore, NavigationService<EquipmentListingVM> equipmentListingNavigationService)
        {
            _hotelStore = hotelStore;
            _vm = vm;
            _equipmentListingNavigationService = equipmentListingNavigationService;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                Console.WriteLine("Try update equipment");
                await _hotelStore.RemoveEquipment(_vm.CurrentItem!.ID);

                _equipmentListingNavigationService.Navigate();
            }
            catch (DataConflictException)
            {
                Console.WriteLine("Due to conflicts, could not remove equipment.");
            }
            catch (Exception)
            {
                Console.WriteLine("An unknown error was thrown. Could not remove equipment.");
                throw;
            }
        }
    }
}