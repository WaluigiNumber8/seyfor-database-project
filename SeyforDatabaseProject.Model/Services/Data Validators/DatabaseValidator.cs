using Microsoft.EntityFrameworkCore;
using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.Model.Services
{
    public class DatabaseValidator : DatabaseServiceBase, IServiceDataValidator
    {
        public DatabaseValidator(DatabaseContextFactory contextFactory) : base(contextFactory) { }
        
        public async Task<Equipment?> ValidateEquipmentAsync(Equipment equipment)
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();
            EquipmentDTO? invalidEquipment = await db.Equipment
                .Where(e => e.Title.Length <= 0)
                .Where(e => e.Description.Length <= 0)
                .FirstOrDefaultAsync();
            
            return invalidEquipment?.Convert();
        }
    }
}