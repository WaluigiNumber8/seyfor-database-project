using System.ComponentModel.DataAnnotations;

namespace SeyforDatabaseProject.Model.DatabaseConnection
{
    public class RoomDTO
    {
        [Key]
        public int ID { get; set; }
        public int RoomNumber { get; set; }
        public int RoomType { get; set; }
        public int Capacity { get; set; }
        public string PricePerNight { get; set; }
        public int AvailabilityStatus { get; set; }

        public ICollection<EquipmentDTO> Equipment { get; set; } = [];
    }
}