using System.Collections.ObjectModel;
using System.Windows.Input;
using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel
{
    public class EquipmentVM : ViewModelBase
    {
        private Hotel _hotel;

        private ObservableCollection<EquipmentItemVM> _equipment;
        public ObservableCollection<EquipmentItemVM> Equipment
        {
            get { return _equipment; }
            set { _equipment = value; }
        }
        
        public ICommand AddEntryCommand { get; }
        public ICommand RefreshEntriesCommand { get; }

        private EquipmentVM(Hotel hotel)
        {
            _hotel = hotel;
            _equipment = new ObservableCollection<EquipmentItemVM>();
            AddEntryCommand = new AddEntryCommand(hotel, this);
            RefreshEntriesCommand = new RefreshEquipmentEntriesCommand(hotel, this);
        }

        public static EquipmentVM Create(Hotel hotel)
        {
            EquipmentVM vm = new(hotel);
            vm.RefreshEntriesCommand.Execute(null);
            return vm;
        }
        
        public void UpdateEntries(IEnumerable<Equipment> allEquipment)
        {
            Equipment.Clear();
            foreach (Equipment e in allEquipment)
            {
                Equipment.Add(new EquipmentItemVM(e));
            }
        }
    }
}