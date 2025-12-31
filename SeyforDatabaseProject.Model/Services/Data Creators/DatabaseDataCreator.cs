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

        public async Task CreateAsync(EquipmentItem newEquipment)
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();
            db.Equipment.Add(newEquipment.ConvertToDTO());
            await db.SaveChangesAsync();
        }

        public async Task CreateAsync<T>(T item) where T : DatabaseItemBase<T>
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();
            switch (item)
            {
                case EquipmentItem equipment:
                    db.Equipment.Add(equipment.ConvertToDTO());
                    break;
                case RoomItem room:
                    db.Rooms.Add(room.ConvertToDTO());
                    break;
            }
            
            await db.SaveChangesAsync();
        }
    }
}