using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Represents a service for updating data.
    /// </summary>
    public interface IServiceDataUpdater
    {
        public Task UpdateAsync<T>(T item) where T : DatabaseItemBase<T>;
    }
}