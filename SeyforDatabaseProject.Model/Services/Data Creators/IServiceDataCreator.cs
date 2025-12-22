using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Represents a service for creating hotel data.
    /// </summary>
    public interface IServiceDataCreator
    {
        Task CreateEquipmentAsync(Equipment newEquipment);
    }
}