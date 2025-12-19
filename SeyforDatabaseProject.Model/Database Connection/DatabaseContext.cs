using Microsoft.EntityFrameworkCore;
using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.Model
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Equipment> Equipment { get; set; }
        public string DbPath { get; }
        public DatabaseContext()
        {
            DbPath = "SeyforDatabaseDB.db";
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Data Source={DbPath}");
        }
    }
}