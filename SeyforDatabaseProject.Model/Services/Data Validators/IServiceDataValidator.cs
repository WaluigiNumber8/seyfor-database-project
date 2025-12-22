using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Represents a service for validating data.
    /// </summary>
    public interface IServiceDataValidator
    {
        public Task<Equipment?> ValidateEquipmentAsync(Equipment equipment);
    }
}