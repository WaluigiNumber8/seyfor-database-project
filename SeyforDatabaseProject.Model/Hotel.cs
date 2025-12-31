using SeyforDatabaseProject.Model.Departments;

namespace SeyforDatabaseProject.Model
{
    /// <summary>
    /// Main access point for hotel data.
    /// </summary>
    public class Hotel
    {
        private readonly HotelBook _book;

        public Hotel(HotelBook book)
        {
            _book = book;
        }
        
        public HotelBook Book => _book;
    }
}