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

        private ObservableCollection<EquipmentItemVM> _equipmentItems;

        public ObservableCollection<EquipmentItemVM> EquipmentItems
        {
            get { return _equipmentItems; }
            set { _equipmentItems = value; }
        }

        #endregion

        public ICommand AddEntryCommand { get; }
        public ICommand EditEntryCommand { get; }
        public ICommand RefreshEntriesCommand { get; }

        public EquipmentListingVM(HotelStore hotelStore, EquipmentEditVM editVM, NavigationService<EquipmentEditVM> equipmentEditNavigationService)
        {
            _equipmentItems = new ObservableCollection<EquipmentItemVM>();
            AddEntryCommand = new AddEquipmentCommand(equipmentEditNavigationService, editVM);
            EditEntryCommand = new EditEquipmentCommand(editVM, equipmentEditNavigationService);
            RefreshEntriesCommand = new RefreshEquipmentEntriesCommand(hotelStore, this);

            RefreshEntriesCommand.Execute(null);
        }

        public void UpdateEntries(IEnumerable<EquipmentItem> allEquipment)
        {
            EquipmentItems.Clear();
            foreach (EquipmentItem e in allEquipment)
            {
                EquipmentItems.Add(new EquipmentItemVM(e));
            }
        }
    }
}