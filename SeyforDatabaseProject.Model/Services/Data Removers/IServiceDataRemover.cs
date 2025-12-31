using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Represents a service for removing hotel data.
    /// </summary>
    public interface IServiceDataRemover
    {
        public Task RemoveAsync<T>(T item) where T : DatabaseItemBase<T>;
    }
}