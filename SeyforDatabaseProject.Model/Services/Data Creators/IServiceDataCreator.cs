using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Represents a service for creating hotel data.
    /// </summary>
    public interface IServiceDataCreator
    {
        Task CreateAsync<T>(T item) where T : DatabaseItemBase<T>;
    }
}