using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Represents a service for updating data.
    /// </summary>
    public interface IServiceDataUpdater
    {
        public Task UpdateEquipmentAsync(EquipmentItem item);
    }
}