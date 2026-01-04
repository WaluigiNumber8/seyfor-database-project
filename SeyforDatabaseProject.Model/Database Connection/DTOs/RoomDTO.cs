using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeyforDatabaseProject.Model.DatabaseConnection
{
    public class RoomDTO
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; init; }
        public int RoomNumber { get; set; }
        public int RoomType { get; set; }
        public int Capacity { get; set; }
        public string PricePerNight { get; set; }
        public int AvailabilityStatus { get; set; }

        public ICollection<EquipmentDTO> Equipment { get; set; } = [];
    }
}