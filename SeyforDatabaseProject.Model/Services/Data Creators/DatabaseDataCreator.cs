using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Creates new data entries in the database.
    /// </summary>
    public class DatabaseDataCreator : DatabaseServiceBase, IServiceDataCreator
    {
        public DatabaseDataCreator(DatabaseContextFactory contextFactory) : base(contextFactory) { }

        public async Task CreateAsync<T>(T item) where T : DatabaseItemBase<T>
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();
            switch (item)
            {
                case EquipmentItem equipment:
                    db.Equipment.Add(equipment.ConvertToDTO());
                    break;
                case RoomItem room:
                    db.Rooms.Add(room.ConvertToDTO());
                    break;
                case GuestItem guest:
                    db.Guests.Add(guest.ConvertToDTO());
                    break;
                case ReservationItem reservation:
                    GuestDTO? guestDTO = await db.Guests.FindAsync(reservation.Guest.ID);
                    RoomDTO? roomDTO = await db.Rooms.FindAsync(reservation.Room.ID);
                    ReservationDTO dato = reservation.ConvertToDTO(guestDTO, roomDTO);
                    db.Reservations.Add(dato);
                    break;
            }
            
            await db.SaveChangesAsync();
        }
    }
}