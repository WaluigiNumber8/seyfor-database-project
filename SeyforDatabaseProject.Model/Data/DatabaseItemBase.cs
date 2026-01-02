using SeyforDatabaseProject.Model.Services;

namespace SeyforDatabaseProject.Model.Data
{
    public abstract class DatabaseItemBase<T> : IIDHolder where T : DatabaseItemBase<T>
    {
        public int ID { get; init; }

        /// <summary>
        /// Updates the equipment item with new data. HAS to have the same ID.
        /// </summary>
        /// <param name="item"></param>
        public void Update(T item)
        {
            if (item.ID != ID)
            {
                throw new DataConflictException($"{item} cannot update {this} because IDs do not match.");
            }
            UpdateFields(item);
        }

        protected abstract void UpdateFields(T item);
    }
}