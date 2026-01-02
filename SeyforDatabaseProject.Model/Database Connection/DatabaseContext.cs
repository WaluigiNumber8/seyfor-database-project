using Microsoft.EntityFrameworkCore;

namespace SeyforDatabaseProject.Model.DatabaseConnection
{
    public class DatabaseContext : DbContext
    {
        public DbSet<EquipmentDTO> Equipment { get; set; }
        public DbSet<RoomDTO> Rooms { get; set; }
        public DbSet<GuestDTO> Guests { get; set; }
        public DbSet<ReservationDTO> Reservations { get; set; }
        
        public DatabaseContext(DbContextOptions options) : base(options)
        {
            Database.EnsureCreated();
        }
    }
}