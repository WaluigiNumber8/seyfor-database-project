using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    public class DatabaseDataUpdater : DatabaseServiceBase, IServiceDataUpdater
    {
        public DatabaseDataUpdater(DatabaseContextFactory contextFactory) : base(contextFactory) { }

        public async Task UpdateAsync<T>(T item) where T : DatabaseItemBase<T>
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();

            switch (item)
            {
                case EquipmentItem equipmentItem:
                    EquipmentDTO? existingEquipmentDTO = await db.Equipment.FindAsync(item.ID);
                    if (existingEquipmentDTO is null)
                    {
                        throw new InvalidOperationException($"Equipment with ID {item.ID} not found.");
                    }

                    db.Equipment.Update(existingEquipmentDTO.UpdateFrom(equipmentItem));
                    break;
                
                case RoomItem roomItem:
                    RoomDTO? existingRoomDTO = await db.Rooms.FindAsync(item.ID);
                    if (existingRoomDTO is null)
                    {
                        throw new InvalidOperationException($"Room with ID {item.ID} not found.");
                    }

                    db.Rooms.Update(existingRoomDTO.UpdateFrom(roomItem));
                    break;
            }

            await db.SaveChangesAsync();
        }
    }
}