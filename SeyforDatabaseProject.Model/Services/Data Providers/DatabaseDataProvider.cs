using Microsoft.EntityFrameworkCore;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.Model.Data.Reservations;
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
                IEnumerable<EquipmentDTO> dtos = await db.Equipment.ToListAsync();
                return dtos.Select(e => e.ConvertToItem() as T)!;
            }
            
            if (typeof(T) == typeof(RoomItem))
            {
                await db.Equipment.ToListAsync();
                IEnumerable<RoomDTO> dtos = await db.Rooms.ToListAsync();
                return dtos.Select(r => r.ConvertToItem() as T)!;
            }
            
            if (typeof(T) == typeof(GuestItem))
            {
                IEnumerable<GuestDTO> dtos = await db.Guests.ToListAsync();
                return dtos.Select(r => r.ConvertToItem() as T)!;
            }
            
            if (typeof(T) == typeof(ReservationItem))
            {
                //Preload required tables to avoid errors
                await db.Guests.ToListAsync();
                await db.Rooms.ToListAsync();
                IEnumerable<ReservationDTO> dtos = await db.Reservations.ToListAsync();
                return dtos.Select(r => r.ConvertToItem() as T)!;
            }

            throw new NotSupportedException($"Type {typeof(T).Name} is not supported by DatabaseDataProvider.");
        }
    }
}