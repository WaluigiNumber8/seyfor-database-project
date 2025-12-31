using Microsoft.EntityFrameworkCore;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Provides data access from the database.
    /// </summary>
    public class DatabaseDataProvider : DatabaseServiceBase, IServiceDataProvider
    {
        public DatabaseDataProvider(DatabaseContextFactory contextFactory) : base(contextFactory) { }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : DatabaseItemBase<T>
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();
            
            if (typeof(T) == typeof(EquipmentItem))
            {
                IEnumerable<EquipmentDTO> equipmentDTOs = await db.Equipment.ToListAsync();
                return equipmentDTOs.Select(e => e.ConvertToItem() as T)!;
            }
            
            if (typeof(T) == typeof(RoomItem))
            {
                IEnumerable<RoomDTO> roomDTOs = await db.Rooms.ToListAsync();
                return roomDTOs.Select(r => r.ConvertToItem() as T)!;
            }

            throw new NotSupportedException($"Type {typeof(T).Name} is not supported by DatabaseDataProvider.");
        }
    }
}