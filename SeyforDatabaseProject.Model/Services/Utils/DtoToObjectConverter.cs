using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.Model.Services
{
    /// <summary>
    /// Converts Data Transfer Objects (DTOs) to domain objects and vice versa.
    /// </summary>
    public static class DtoToObjectConverter
    {
        public static Equipment Convert(this EquipmentDTO dto)
        {
            return new Equipment
            {
                ID = dto.ID,
                Title = dto.Title,
                Description = dto.Description
            };
        }

        public static EquipmentDTO Convert(this Equipment equipment)
        {
            EquipmentDTO dto = new();
            dto.ID = equipment.ID;
            dto.Title = equipment.Title;
            dto.Description = equipment.Description;
            return dto;
        }
    }
}