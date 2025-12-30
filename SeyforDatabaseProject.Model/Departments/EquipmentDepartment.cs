using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;

namespace SeyforDatabaseProject.Model.Departments
{
    /// <summary>
    /// Represents a department responsible for equipment.
    /// </summary>
    public class EquipmentDepartment
    {
        private readonly IServiceDataProvider _serviceDataProvider;
        private readonly IServiceDataCreator _serviceDataCreator;
        private readonly IServiceDataUpdater _serviceDataUpdater;
        private readonly IServiceDataValidator _serviceDataValidator;

        public EquipmentDepartment(IServiceDataProvider serviceDataProvider, IServiceDataCreator serviceDataCreator, IServiceDataUpdater serviceDataUpdater, IServiceDataValidator serviceDataValidator)
        {
            _serviceDataProvider = serviceDataProvider;
            _serviceDataCreator = serviceDataCreator;
            _serviceDataUpdater = serviceDataUpdater;
            _serviceDataValidator = serviceDataValidator;
        }

        public async Task AddNew(EquipmentItem item)
        {
            EquipmentItem? existingEquipment = await _serviceDataValidator.ValidateEquipmentAsync(item);
            if (existingEquipment != null)
            {
                throw new DataConflictException($"{item} cannot be added because its fields ahd a conflict.");
            }
            
            await _serviceDataCreator.CreateEquipmentAsync(item);
            Console.WriteLine("New equipment added - " + item);
        }

        public async Task Update(EquipmentItem item)
        {
            EquipmentItem? existingEquipment = await _serviceDataValidator.ValidateEquipmentAsync(item);
            if (existingEquipment != null)
            {
                throw new DataConflictException($"{item} cannot be added because its fields ahd a conflict.");
            }
            
            await _serviceDataUpdater.UpdateEquipmentAsync(item);
            Console.WriteLine($"Updated {item} successfully.");
        }
        
        public async Task<IEnumerable<EquipmentItem>> GetAll()
        {
            return await _serviceDataProvider.GetAllEquipmentAsync();
        }
    }
}