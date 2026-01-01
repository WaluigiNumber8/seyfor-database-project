using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class EquipmentItemVM : DatabaseItemVMBase<EquipmentItem>
    {
        public string Title { get => _item.Title; }

        public string Description { get => _item.Description; }

        public EquipmentItemVM(EquipmentItem item) : base(item) { }
        
        public override string ToString() => $"{ID} - {Title}";
    }
}