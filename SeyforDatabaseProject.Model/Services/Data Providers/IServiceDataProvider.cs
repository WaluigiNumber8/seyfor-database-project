using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Represents a service for providing data access.
    /// </summary>
    public interface IServiceDataProvider
    {
        public Task<IEnumerable<T>> GetAllAsync<T>() where T : DatabaseItemBase<T>;
    }
}