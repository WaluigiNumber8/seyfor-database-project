using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.ViewModel
{
    /// <summary>
    /// Single access point for hotel data in the ViewModel layer.
    /// </summary>
    public class HotelStore
    {
        private readonly Hotel _hotel;
        private readonly List<EquipmentItem> _equipment;
        private Lazy<Task> _initializeEquipmentTask;
        
        public IEnumerable<EquipmentItem> Equipment { get => _equipment; }
        
        public HotelStore(Hotel hotel)
        {
            _hotel = hotel;
            _equipment = new List<EquipmentItem>();
            _initializeEquipmentTask = new Lazy<Task>(InitializeEquipmentAsync);
        }

        public async Task LoadEquipment()
        {
            try
            {
                await _initializeEquipmentTask.Value;
            }
            catch (Exception)
            {
                _initializeEquipmentTask = new Lazy<Task>(InitializeEquipmentAsync);
                throw;
            }
        }
        
        public async Task AddNewEquipment(EquipmentItem newEquipment)
        {
            await _hotel.Equipment.AddNew(newEquipment);
            _equipment.Add(newEquipment);
        }
        
        private async Task InitializeEquipmentAsync()
        {
           IEnumerable<EquipmentItem> equipmentItems = await _hotel.Equipment.GetAll();
           _equipment.Clear();
           _equipment.AddRange(equipmentItems);
        }
    }
}