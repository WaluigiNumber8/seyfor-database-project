using SeyforDatabaseProject.Model.Data;

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
            {
                ID = dto.ID,
                Title = dto.Title,
                Description = dto.Description
            };
        }

        public static EquipmentDTO ConvertToDTO(this EquipmentItem equipment)
        {
            EquipmentDTO dto = new();
            dto.ID = equipment.ID;
            dto.Title = equipment.Title;
            dto.Description = equipment.Description;
            return dto;
        }
    }
}