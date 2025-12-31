namespace SeyforDatabaseProject.Model.Data
{
    public abstract class DatabaseItemBase<T> where T : DatabaseItemBase<T>
    {
        public int ID { get; init; }

        /// <summary>
        /// Updates the equipment item with new data. HAS to have the same ID.
        /// </summary>
        /// <param name="item"></param>
        public abstract void Update(T item);
    }
}