using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel
{
    public class EquipmentItemVM : ViewModelBase
    {
        public int ID { get; init; }
        public string Title { get; init; }
        public string Description { get; init; }
        
        public EquipmentItemVM(Equipment equipment)
        {
            ID = equipment.ID;
            Title = equipment.Title;
            Description = equipment.Description;
        }
    }
}