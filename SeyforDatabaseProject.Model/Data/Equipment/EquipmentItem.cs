using SeyforDatabaseProject.Model.Services;

namespace SeyforDatabaseProject.Model.Data
{
    /// <summary>
    /// Represents an equipment item in the database.
    /// </summary>
    public class EquipmentItem : DatabaseItemBase<EquipmentItem>
    {
        public string Title { get; private set; }
        public string Description { get; private set; }

        public EquipmentItem(int id, string title, string description)
        {
            ID = id;
            Title = title;
            Description = description;
        }
        
        /// <summary>
        /// Updates the equipment item with new data. HAS to have the same ID.
        /// </summary>
        /// <param name="item"></param>
        public override void Update(EquipmentItem item)
        {
            if (item.ID != ID)
            {
                throw new DataConflictException($"{item} cannot update {this} because IDs do not match.");
            }
            Title = item.Title;
            Description = item.Description;
        }

        public override string ToString() => $"{ID} - {Title}";
    }
}