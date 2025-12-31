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
        private readonly List<EquipmentItem> _equipmentItems;
        private Lazy<Task> _initializeEquipmentTask;
        
        public IEnumerable<EquipmentItem> EquipmentItems { get => _equipmentItems; }
        public int EquipmentCount { get => _equipmentItems.Count; }
        
        public HotelStore(Hotel hotel)
        {
            _hotel = hotel;
            _equipmentItems = new List<EquipmentItem>();
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
        
        public async Task AddNewEquipment(EquipmentItem item)
        {
            await _hotel.Equipment.AddNew(item);
            _equipmentItems.Add(item);
        }

        public async Task UpdateEquipment(EquipmentItem item)
        {
            await _hotel.Equipment.Update(item);
            EquipmentItem? itemToUpdate = _equipmentItems.Find(e => e.ID == item.ID);
            
            if (itemToUpdate == null) throw new InvalidOperationException("Item to update not found in store.");
            itemToUpdate.Update(item);
        }
        
        public async Task RemoveEquipment(int id)
        {
            EquipmentItem? item = _equipmentItems.Find(e => e.ID == id);
            
            if (item == null) throw new InvalidOperationException("Item to remove not found in store.");
            await _hotel.Equipment.Remove(item);
            _equipmentItems.Remove(item);
        }
        
        private async Task InitializeEquipmentAsync()
        {
           IEnumerable<EquipmentItem> equipmentItems = await _hotel.Equipment.GetAll<EquipmentItem>();
           _equipmentItems.Clear();
           _equipmentItems.AddRange(equipmentItems);
        }
    }
}