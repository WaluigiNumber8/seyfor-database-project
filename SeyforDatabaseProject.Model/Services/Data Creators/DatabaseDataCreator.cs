using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Creates new data entries in the database.
    /// </summary>
    public class DatabaseDataCreator : DatabaseServiceBase, IServiceDataCreator
    {
        public DatabaseDataCreator(DatabaseContextFactory contextFactory) : base(contextFactory) { }

        public async Task CreateEquipmentAsync(EquipmentItem newEquipment)
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();
            db.Equipment.Add(newEquipment.ConvertToDTO());
            await db.SaveChangesAsync();
        }
    }
}