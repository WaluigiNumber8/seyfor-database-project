using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Removes data from the database.
    /// </summary>
    public class DatabaseDataRemover : DatabaseServiceBase, IServiceDataRemover
    {
        public DatabaseDataRemover(DatabaseContextFactory contextFactory) : base(contextFactory)
        {
        }

        public async Task RemoveAsync<T>(T item) where T : DatabaseItemBase<T>
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();
            switch (item)
            {
                case EquipmentItem equipment:
                    db.Equipment.Remove(equipment.ConvertToDTO());
                    break;
                case RoomItem room:
                    List<EquipmentDTO> equipmentDTOs = await ServiceUtils.GetEquipmentDTOsForRoom(db, room);
                    db.Rooms.Remove(room.ConvertToDTO(equipmentDTOs));
                    break;
                case GuestItem guest:
                    db.Guests.Remove(guest.ConvertToDTO());
                    break;
                case ReservationItem reservation:
                    (GuestDTO guestDTO, RoomDTO roomDTO) = await ServiceUtils.GetGuestAndRoomForReservation(db, reservation);
                    db.Reservations.Remove(reservation.ConvertToDTO(guestDTO, roomDTO));
                    break;
            }

            await db.SaveChangesAsync();
        }
    }
}