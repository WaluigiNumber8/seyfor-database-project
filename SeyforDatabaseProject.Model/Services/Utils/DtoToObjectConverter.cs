using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.DatabaseConnection;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Converts Data Transfer Objects (DTOs) to domain objects and vice versa.
    /// </summary>
    public static class DtoToObjectConverter
    {
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
    }
}