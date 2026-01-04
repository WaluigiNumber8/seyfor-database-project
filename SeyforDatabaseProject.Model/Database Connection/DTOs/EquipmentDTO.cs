using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeyforDatabaseProject.Model.DatabaseConnection
{
    /// <summary> 
    /// Data Transfer Object for Equipment.
    /// </summary>
    public class EquipmentDTO
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public string Title { get; set; }
        public string Description { get; set; }
    }
}