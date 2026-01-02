using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;

namespace SeyforDatabaseProject.Model.Departments
{
    /// <summary>
    /// Represents a book for managing hotel-related data.
    /// </summary>
    public class HotelBook
    {
        private readonly IServiceDataProvider _serviceDataProvider;
        private readonly IServiceDataCreator _serviceDataCreator;
        private readonly IServiceDataUpdater _serviceDataUpdater;
        private readonly IServiceDataRemover _serviceDataRemover;
        private readonly IServiceDataValidator _serviceDataValidator;

        public HotelBook(IServiceDataProvider serviceDataProvider, IServiceDataCreator serviceDataCreator, IServiceDataUpdater serviceDataUpdater, IServiceDataRemover serviceDataRemover, IServiceDataValidator serviceDataValidator)
        {
            _serviceDataProvider = serviceDataProvider;
            _serviceDataCreator = serviceDataCreator;
            _serviceDataUpdater = serviceDataUpdater;
            _serviceDataValidator = serviceDataValidator;
            _serviceDataRemover = serviceDataRemover;
        }

        public async Task AddNew<T>(T item) where T : DatabaseItemBase<T>
        {
            T? existingItem = await _serviceDataValidator.ValidateAsync(item);
            if (existingItem != null)
            {
                throw new DataConflictException($"{item} cannot be added because its fields ahd a conflict.");
            }

            await _serviceDataCreator.CreateAsync(item);
            Console.WriteLine($"New item added - {item}");
        }

        public async Task Update<T>(T item) where T : DatabaseItemBase<T>
        {
            T? existingItem = await _serviceDataValidator.ValidateAsync(item);
            if (existingItem != null)
            {
                throw new DataConflictException($"{item} cannot be added because its fields ahd a conflict.");
            }

            await _serviceDataUpdater.UpdateAsync(item);
            Console.WriteLine($"Updated {item} successfully.");
        }

        public async Task<IEnumerable<T>> GetAll<T>() where T : DatabaseItemBase<T>
        {
            return await _serviceDataProvider.GetAllAsync<T>();
        }

        public async Task Remove<T>(T item) where T : DatabaseItemBase<T>
        {
            await _serviceDataRemover.RemoveAsync(item);
            Console.WriteLine("Equipment removed with ID: " + item.ID);
        }
    }
}