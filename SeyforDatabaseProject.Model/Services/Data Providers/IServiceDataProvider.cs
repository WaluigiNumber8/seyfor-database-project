using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Represents a service for providing data access.
    /// </summary>
    public interface IServiceDataProvider
    {
        Task<IEnumerable<EquipmentItem>> GetAllEquipmentAsync();
    }
}