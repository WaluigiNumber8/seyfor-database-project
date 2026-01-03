using System.Data;
using Microsoft.EntityFrameworkCore;
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
        public DatabaseDataCreator(DatabaseContextFactory contextFactory) : base(contextFactory)
        {
        }

        public async Task CreateAsync<T>(T item) where T : DatabaseItemBase<T>
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();
            switch (item)
            {
                case EquipmentItem equipment:
                    db.Equipment.Add(equipment.ConvertToDTO());
                    break;

                case RoomItem room:
                    List<EquipmentDTO> equipmentDTOs = await ServiceUtils.GetEquipmentDTOsForRoom(db, room);
                    db.Rooms.Add(room.ConvertToDTO(equipmentDTOs));
                    break;

                case GuestItem guest:
                    db.Guests.Add(guest.ConvertToDTO());
                    break;

                case ReservationItem reservation:
                    (GuestDTO guestDTO, RoomDTO roomDTO) = await ServiceUtils.GetGuestAndRoomForReservation(db, reservation);
                    ReservationDTO dato = reservation.ConvertToDTO(guestDTO, roomDTO);
                    db.Reservations.Add(dato);
                    break;
            }

            await db.SaveChangesAsync();
        }

        
    }
}