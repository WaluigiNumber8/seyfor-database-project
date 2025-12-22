using SeyforDatabaseProject.Model.Departments;

namespace SeyforDatabaseProject.Model
{
    /// <summary>
    /// Main access point for hotel data.
    /// </summary>
    public class Hotel
    {
        private readonly EquipmentDepartment _equipment;

        public Hotel(EquipmentDepartment equipment)
        {
            _equipment = equipment;
        }
        
        public EquipmentDepartment Equipment => _equipment;
    }
}