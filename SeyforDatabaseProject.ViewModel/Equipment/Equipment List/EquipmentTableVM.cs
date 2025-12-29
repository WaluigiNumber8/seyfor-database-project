using System.Collections.ObjectModel;
using System.Windows.Input;
using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class EquipmentTableVM : ViewModelBase
    {
        private ObservableCollection<EquipmentItemVM> _equipment;
        public ObservableCollection<EquipmentItemVM> Equipment
        {
            get { return _equipment; }
            set { _equipment = value; }
        }
        
        public ICommand AddEntryCommand { get; }
        public ICommand RefreshEntriesCommand { get; }

        private EquipmentTableVM(Hotel hotel)
        {
            _equipment = new ObservableCollection<EquipmentItemVM>();
            AddEntryCommand = new AddEntryCommand(hotel, this);
            RefreshEntriesCommand = new RefreshEquipmentEntriesCommand(hotel, this);
        }

        public static EquipmentTableVM Create(Hotel hotel)
        {
            EquipmentTableVM vm = new(hotel);
            vm.RefreshEntriesCommand.Execute(null);
            return vm;
        }
        
        public void UpdateEntries(IEnumerable<EquipmentItem> allEquipment)
        {
            Equipment.Clear();
            foreach (EquipmentItem e in allEquipment)
            {
                Equipment.Add(new EquipmentItemVM(e));
            }
        }
    }
}