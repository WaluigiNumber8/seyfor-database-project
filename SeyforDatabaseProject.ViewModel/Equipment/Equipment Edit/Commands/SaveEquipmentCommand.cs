using System;
using System.Threading.Tasks;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    /// <summary>
    /// Command for adding new equipment to database.
    /// </summary>
    public class SaveEquipmentCommand : AsyncCommandBase
    {
        private readonly EquipmentEditVM _vm;
        private readonly HotelStore _hotelStore;
        private readonly NavigationService<EquipmentListingVM> _equipmentListingNavigationService;

        public SaveEquipmentCommand(EquipmentEditVM vm, HotelStore hotel, NavigationService<EquipmentListingVM> equipmentListingNavigationService)
        {
            _vm = vm;
            _hotelStore = hotel;
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
                await _hotelStore.AddNewEquipment(newEquipment);
                
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