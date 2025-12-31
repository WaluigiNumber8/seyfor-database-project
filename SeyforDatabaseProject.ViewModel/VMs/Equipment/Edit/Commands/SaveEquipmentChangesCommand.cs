using System;
using System.Threading.Tasks;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class SaveEquipmentChangesCommand : AsyncCommandBase
    {
        private readonly EquipmentEditVM _vm;
        private readonly HotelStore _hotelStore;
        private readonly NavigationService<EquipmentListingVM> _equipmentListingNavigationService;

        public SaveEquipmentChangesCommand(EquipmentEditVM vm, HotelStore hotel, NavigationService<EquipmentListingVM> equipmentListingNavigationService)
        {
            _vm = vm;
            _hotelStore = hotel;
            _equipmentListingNavigationService = equipmentListingNavigationService;
        }

        public override async Task ExecuteAsync(object? parameter)
        {
            try
            {
                EquipmentItem item = new(_vm.CurrentItem!.ID, _vm.Title, _vm.Description);
                Console.WriteLine("Try update equipment");
                await _hotelStore.Equipment.Update(item);

                _equipmentListingNavigationService.Navigate();
            }
            catch (DataConflictException)
            {
                Console.WriteLine("Due to conflicts, could not create equipment.");
            }
            catch (Exception)
            {
                Console.WriteLine("An unknown error was thrown. Could not create equipment.");
                throw;
            }
        }
    }
}