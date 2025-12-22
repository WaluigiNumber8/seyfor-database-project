using Microsoft.EntityFrameworkCore;
using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Provides data access from the database.
    /// </summary>
    public class DatabaseDataProvider : DatabaseServiceBase, IServiceDataProvider
    {
        public DatabaseDataProvider(DatabaseContextFactory contextFactory) : base(contextFactory) { }

        public async Task<IEnumerable<Equipment>> GetAllEquipmentAsync()
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();
            IEnumerable<EquipmentDTO> equipmentDTOs = await db.Equipment.ToListAsync();
            return equipmentDTOs.Select(e => e.Convert());
        }
    }
}