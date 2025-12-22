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
        private readonly IServiceDataValidator _serviceDataValidator;

        public EquipmentDepartment(IServiceDataProvider serviceDataProvider, IServiceDataCreator serviceDataCreator, IServiceDataValidator serviceDataValidator)
        {
            _serviceDataProvider = serviceDataProvider;
            _serviceDataCreator = serviceDataCreator;
            _serviceDataValidator = serviceDataValidator;
        }

        public async Task AddNew(Equipment newEquipment)
        {
            Equipment? existingEquipment = await _serviceDataValidator.ValidateEquipmentAsync(newEquipment);
            if (existingEquipment != null)
            {
                throw new DataConflictException($"");
            }
            
            await _serviceDataCreator.CreateEquipmentAsync(newEquipment);
            Console.WriteLine("New equipment added with ID: " + newEquipment.ID);
        }
        
        public async Task<IEnumerable<Equipment>> GetAll()
        {
            return await _serviceDataProvider.GetAllEquipmentAsync();
        }
    }
}