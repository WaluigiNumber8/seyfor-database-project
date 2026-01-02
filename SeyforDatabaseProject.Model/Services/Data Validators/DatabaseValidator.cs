using Microsoft.EntityFrameworkCore;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Data.Guests;
using SeyforDatabaseProject.Model.Data.Reservations;
using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    public class DatabaseValidator : DatabaseServiceBase, IServiceDataValidator
    {
        public DatabaseValidator(DatabaseContextFactory contextFactory) : base(contextFactory)
        {
        }

        public async Task<EquipmentItem?> ValidateEquipmentAsync(EquipmentItem equipment)
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();
            EquipmentDTO? invalidEquipment = await db.Equipment
                .Where(e => e.Title.Length <= 0)
                .Where(e => e.Description.Length <= 0)
                .FirstOrDefaultAsync();

            return invalidEquipment?.ConvertToItem();
        }

        public async Task<T?> ValidateAsync<T>(T item) where T : DatabaseItemBase<T>
        {
            await using DatabaseContext db = _contextFactory.CreateDbContext();
            switch (item)
            {
                case EquipmentItem:
                    EquipmentDTO? invalidEquipment = await db.Equipment
                        .Where(e => e.Title.Length <= 0)
                        .Where(e => e.Description.Length <= 0)
                        .FirstOrDefaultAsync();

                    return invalidEquipment?.ConvertToItem() as T;

                case RoomItem:
                    RoomDTO? invalidRoom = await db.Rooms
                        .Where(r => r.RoomNumber <= 0)
                        .Where(r => r.Capacity <= 0)
                        .FirstOrDefaultAsync();
                    return invalidRoom?.ConvertToItem() as T;
                
                case GuestItem:
                    GuestDTO? invalidGuest = await db.Guests
                        .Where(r => r.Name.Length <= 0)
                        .Where(r => r.Surname.Length <= 0)
                        .Where(r => r.Email.Length <= 0)
                        .Where(r => r.PhoneNumber.Length <= 0)
                        .FirstOrDefaultAsync();
                    return invalidGuest?.ConvertToItem() as T;
                
                case ReservationItem:
                    ReservationDTO? invalidReservation = await db.Reservations
                        .Where(r => r.PriceTotal < 0)
                        .FirstOrDefaultAsync();
                    return invalidReservation?.ConvertToItem() as T;
            }

            throw new NotSupportedException($"Type {typeof(T).Name} is not supported by DatabaseValidator.");
        }
    }
}