using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Data;

namespace SeyforDatabaseProject.ViewModel
{
    /// <summary>
    /// List that manages database items of type T. Allows CRUD operations and lazy loading.
    /// </summary>
    public class DatabaseItemList<T> where T : DatabaseItemBase<T>
    {
        private readonly Hotel _hotel;
        private readonly List<T> _items;
        private Lazy<Task> _initTask;

        public int Count { get => _items.Count; }
        public IEnumerable<T> Items { get => _items; }

        public DatabaseItemList(Hotel hotel)
        {
            _hotel = hotel;
            _items = new List<T>();
            _initTask = new Lazy<Task>(InitializeEquipmentAsync);
        }
        
        public async Task Load()
        {
            try
            {
                await _initTask.Value;
            }
            catch (Exception)
            {
                _initTask = new Lazy<Task>(InitializeEquipmentAsync);
                throw;
            }
        }
        
        public async Task AddNew(T item)
        {
            await _hotel.Book.AddNew(item);
            _items.Add(item);
        }
        
        public async Task Update(T item)
        {
            await _hotel.Book.Update(item);
            T? itemToUpdate = _items.Find(e => e.ID == item.ID);
            
            if (itemToUpdate == null) throw new InvalidOperationException($"Item |{item}| to update not found in store.");
            itemToUpdate.Update(item);
        }
        
        public async Task Remove(int id)
        {
            T? item = _items.Find(e => e.ID == id);
            
            if (item == null) throw new InvalidOperationException("Item to remove not found in store.");
            await _hotel.Book.Remove(item);
            _items.Remove(item);
        }
        
        private async Task InitializeEquipmentAsync()
        {
            IEnumerable<T> databaseItems = await _hotel.Book.GetAll<T>();
            _items.Clear();
            _items.AddRange(databaseItems);
        }
    }
}