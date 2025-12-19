using System.Collections.ObjectModel;
using System.Windows.Input;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel
{
    public class EquipmentVM : ViewModelBase
    {
        private ObservableCollection<EquipmentItemVM> equipment;
        public ObservableCollection<EquipmentItemVM> Equipment
        {
            get { return equipment; }
            set { equipment = value; }
        }
        
        public ICommand AddEntryCommand { get; }
    }
}