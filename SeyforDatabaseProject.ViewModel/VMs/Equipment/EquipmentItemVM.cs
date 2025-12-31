using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class EquipmentItemVM : ViewModelBase
    {
        public int ID { get => _item.ID; }
        public string Title { get => _item.Title; }
        public string Description { get => _item.Description; }

        private readonly EquipmentItem _item;

        public EquipmentItemVM(EquipmentItem equipment)
        {
            _item = equipment;
        }

        public override string ToString() => $"{ID} - {Title}";
    }
}