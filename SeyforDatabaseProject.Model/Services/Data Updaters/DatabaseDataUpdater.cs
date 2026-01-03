using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    public class DatabaseDataUpdater : DatabaseServiceBase, IServiceDataUpdater
    {
        public DatabaseDataUpdater(DatabaseContextFactory contextFactory) : base(contextFactory) { }

        public async Task UpdateAsync<T>(T item) where T : DatabaseItemBase<T>
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();

            switch (item)
            {
                case EquipmentItem equipmentItem:
                    EquipmentDTO? existingEquipmentDTO = await db.Equipment.FindAsync(item.ID);
                    if (existingEquipmentDTO is null)
                    {
                        throw new InvalidOperationException($"Equipment with ID {item.ID} not found.");
                    }

                    db.Equipment.Update(existingEquipmentDTO.UpdateFrom(equipmentItem));
                    break;
                
                case RoomItem roomItem:
                    RoomDTO? existingRoomDTO = await db.Rooms.FindAsync(item.ID);
                    if (existingRoomDTO is null)
                    {
                        throw new InvalidOperationException($"Room with ID {item.ID} not found.");
                    }

                    db.Rooms.Update(existingRoomDTO.UpdateFrom(roomItem));
                    break;
                
                case GuestItem guestItem:
                    GuestDTO? existingGuestDTO = await db.Guests.FindAsync(item.ID);
                    if (existingGuestDTO is null)
                    {
                        throw new InvalidOperationException($"Guest with ID {item.ID} not found.");
                    }

                    db.Guests.Update(existingGuestDTO.UpdateFrom(guestItem));
                    break;
                
                case ReservationItem reservationItem:
                    ReservationDTO? existingReservationDTO = await db.Reservations.FindAsync(item.ID);
                    if (existingReservationDTO is null)
                    {
                        throw new InvalidOperationException($"Guest with ID {item.ID} not found.");
                    }
                    GuestDTO? guestDTO = await db.Guests.FindAsync(reservationItem.Guest.ID);
                    RoomDTO? roomDTO = await db.Rooms.FindAsync(reservationItem.Room.ID);
                    db.Reservations.Update(existingReservationDTO.UpdateFrom(reservationItem, guestDTO, roomDTO));
                    break;
            }

            await db.SaveChangesAsync();
        }
    }
}