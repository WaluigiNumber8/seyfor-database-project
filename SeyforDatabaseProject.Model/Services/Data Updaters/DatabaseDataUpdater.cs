using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    public class DatabaseDataUpdater : DatabaseServiceBase, IServiceDataUpdater
    {
        public DatabaseDataUpdater(DatabaseContextFactory contextFactory) : base(contextFactory) { }

        public async Task UpdateEquipmentAsync(EquipmentItem item)
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();
            
            EquipmentDTO? existingDTO = await db.Equipment.FindAsync(item.ID);
            if (existingDTO is null)
            {
                throw new InvalidOperationException($"Equipment with ID {item.ID} not found.");
            }

            db.Equipment.Update(existingDTO.UpdateFrom(item));
            await db.SaveChangesAsync();
        }
    }
}