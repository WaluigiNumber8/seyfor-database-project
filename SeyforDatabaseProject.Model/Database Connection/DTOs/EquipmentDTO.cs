using System.ComponentModel.DataAnnotations;

namespace SeyforDatabaseProject.Model.DatabaseConnection
{
    /// <summary>
    /// Data Transfer Object for Equipment.
    /// </summary>
    public class EquipmentDTO
    {
        [Key] 
        public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
    }
}