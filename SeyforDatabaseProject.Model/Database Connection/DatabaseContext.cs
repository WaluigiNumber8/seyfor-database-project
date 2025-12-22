using Microsoft.EntityFrameworkCore;

namespace SeyforDatabaseProject.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<EquipmentDTO> Equipment { get; set; }
        
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}