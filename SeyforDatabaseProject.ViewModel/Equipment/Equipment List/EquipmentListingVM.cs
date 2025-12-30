using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using SeyforDatabaseProject.Model.Data;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Navigation;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class EquipmentListingVM : ViewModelBase
    {
        #region Properties

        private ObservableCollection<EquipmentItemVM> _equipment;

        public ObservableCollection<EquipmentItemVM> Equipment
        {
            get { return _equipment; }
            set { _equipment = value; }
        }

        #endregion

        public ICommand AddEntryCommand { get; }
        public ICommand RefreshEntriesCommand { get; }
        public ICommand EditEntryCommand { get; }

        public EquipmentListingVM(HotelStore hotelStore, EquipmentEditVM editVM, NavigationService<EquipmentEditVM> equipmentEditNavigationService)
        {
            _equipment = new ObservableCollection<EquipmentItemVM>();
            AddEntryCommand = new AddEquipmentCommand(equipmentEditNavigationService, editVM);
            EditEntryCommand = new EditEquipmentCommand(editVM, equipmentEditNavigationService);
            RefreshEntriesCommand = new RefreshEquipmentEntriesCommand(hotelStore, this);

            RefreshEntriesCommand.Execute(null);
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