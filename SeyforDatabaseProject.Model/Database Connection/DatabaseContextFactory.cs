using Microsoft.EntityFrameworkCore;

namespace SeyforDatabaseProject.Model.DatabaseConnection
{
    /// <summary>
    /// Creates instances of DatabaseContext.
    /// </summary>
    public class DatabaseContextFactory
    {
        private readonly string _connectionString;
        
        public DatabaseContextFactory(string connectionString)
        {
            _connectionString = connectionString;
        }
        
        public DatabaseContext CreateDbContext()
        {
            DbContextOptions<DatabaseContext> options = new DbContextOptionsBuilder<DatabaseContext>().UseSqlite(_connectionString).Options;
            return new DatabaseContext(options);
        }
    }
}