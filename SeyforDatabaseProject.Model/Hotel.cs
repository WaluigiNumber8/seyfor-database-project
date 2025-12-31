using SeyforDatabaseProject.Model.Departments;

namespace SeyforDatabaseProject.Model
{
    /// <summary>
    /// Main access point for hotel data.
    /// </summary>
    public class Hotel
    {
        private readonly HotelBook _equipment;

        public Hotel(HotelBook equipment)
        {
            _equipment = equipment;
        }
        
        public HotelBook Equipment => _equipment;
    }
}