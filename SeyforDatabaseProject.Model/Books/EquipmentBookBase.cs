using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.Model.Services;

namespace SeyforDatabaseProject.Model.Departments
{
    public abstract class EquipmentBookBase<T> where T : DatabaseItemBase<T>
    {
        protected readonly IServiceDataProvider _serviceDataProvider;
        protected readonly IServiceDataCreator _serviceDataCreator;
        protected readonly IServiceDataUpdater _serviceDataUpdater;
        protected readonly IServiceDataRemover _serviceDataRemover;
        protected readonly IServiceDataValidator _serviceDataValidator;

        public EquipmentBookBase(IServiceDataProvider serviceDataProvider, IServiceDataCreator serviceDataCreator, IServiceDataUpdater serviceDataUpdater, IServiceDataRemover serviceDataRemover, IServiceDataValidator serviceDataValidator)
        {
            _serviceDataProvider = serviceDataProvider;
            _serviceDataCreator = serviceDataCreator;
            _serviceDataUpdater = serviceDataUpdater;
            _serviceDataValidator = serviceDataValidator;
            _serviceDataRemover = serviceDataRemover;
        }

        public abstract Task AddNew(T item);
        public abstract Task Update(T item);
        public abstract Task<IEnumerable<T>> GetAll();
        public abstract Task Remove(T equipmentToRemove);
    }
}