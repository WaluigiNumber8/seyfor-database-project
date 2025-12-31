using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Removes data from the database.
    /// </summary>
    public class DatabaseDataRemover : DatabaseServiceBase, IServiceDataRemover
    {
        public DatabaseDataRemover(DatabaseContextFactory contextFactory) : base(contextFactory) { }

        public async Task RemoveEquipmentAsync(EquipmentItem item)
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();
            db.Equipment.Remove(item.ConvertToDTO());
            await db.SaveChangesAsync();
        }
    }
}