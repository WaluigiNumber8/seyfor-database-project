using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Converts Data Transfer Objects (DTOs) to domain objects and vice versa.
    /// </summary>
    public static class DtoToObjectConverter
    {
        #region Equipment

        public static EquipmentItem ConvertToItem(this EquipmentDTO dto)
        {
            return new EquipmentItem
            (
                dto.ID,
                dto.Title,
                dto.Description
            );
        }

        public static EquipmentDTO ConvertToDTO(this EquipmentItem equipment)
        {
            EquipmentDTO dto = new();
            dto.ID = equipment.ID;
            dto.Title = equipment.Title;
            dto.Description = equipment.Description;
            return dto;
        }

        public static EquipmentDTO UpdateFrom(this EquipmentDTO dto, EquipmentItem equipment)
        {
            dto.Title = equipment.Title;
            dto.Description = equipment.Description;
            return dto;
        }

        #endregion

        #region Room

        public static RoomItem ConvertToItem(this RoomDTO dto)
        {
            return new RoomItem(
                dto.ID,
                dto.RoomNumber,
                (RoomType) dto.RoomType,
                dto.Capacity,
                Convert.ToDecimal(dto.PricePerNight),
                (RoomAvailabilityStatus) dto.AvailabilityStatus
            );
        }
        
        public static RoomDTO ConvertToDTO(this RoomItem room)
        {
            RoomDTO dto = new();
            dto.ID = room.ID;
            dto.RoomNumber = room.RoomNumber;
            dto.RoomType = (int) room.RoomType;
            dto.Capacity = room.Capacity;
            dto.PricePerNight = room.PricePerNight.ToString();
            dto.AvailabilityStatus = (int) room.AvailabilityStatus;
            return dto;
        }
        
        public static RoomDTO UpdateFrom(this RoomDTO dto, RoomItem room)
        {
            dto.RoomNumber = room.RoomNumber;
            dto.RoomType = (int) room.RoomType;
            dto.Capacity = room.Capacity;
            dto.PricePerNight = room.PricePerNight.ToString();
            dto.AvailabilityStatus = (int) room.AvailabilityStatus;
            return dto;
        }

        #endregion
    }
}