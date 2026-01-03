using System.Data;
using Microsoft.EntityFrameworkCore;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Contains utility methods for database services.
    /// </summary>
    public static class ServiceUtils
    {
        public static async Task<List<EquipmentDTO>> GetEquipmentDTOsForRoom(DatabaseContext db, RoomItem room)
        {
            List<int> equipmentIds = room.Equipment.Select(e => e.ID).ToList();
            List<EquipmentDTO> equipmentDTOs = await db.Equipment.Where(e => equipmentIds.Contains(e.ID)).ToListAsync();

            if (equipmentDTOs.Count != equipmentIds.Count)
            {
                IEnumerable<int> missing = equipmentIds.Except(equipmentDTOs.Select(d => d.ID));
                throw new DataException($"Could not find DTOs for equipment IDs: {string.Join(", ", missing)} in Equipment.");
            }

            return equipmentDTOs;
        }
        
        public static async Task<(GuestDTO guestDTO, RoomDTO roomDTO)> GetGuestAndRoomForReservation(DatabaseContext db, ReservationItem reservationItem)
        {
            GuestDTO? guestDTO = await db.Guests.FindAsync(reservationItem.Guest.ID);
            RoomDTO? roomDTO = await db.Rooms.FindAsync(reservationItem.Room.ID);
            if (guestDTO == null) throw new DataException($"Could not find DTO for '{reservationItem.Guest}' in database.");
            if (roomDTO == null) throw new DataException($"Could not find DTO for '{reservationItem.Room}' in database.");
            
            return (guestDTO, roomDTO);
        }
    }
}