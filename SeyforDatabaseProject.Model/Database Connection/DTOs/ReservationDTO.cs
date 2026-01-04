using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SeyforDatabaseProject.Model.DatabaseConnection
{
    public class ReservationDTO
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string DateStart { get; set; }
        public string DateEnd { get; set; }
        public int State { get; set; }
        public int PriceTotal { get; set; }
        public int RoomID { get; set; }
        public int GuestID { get; set; }
        
        public GuestDTO Guest { get; set; }
        public RoomDTO Room { get; set; }
    }
}