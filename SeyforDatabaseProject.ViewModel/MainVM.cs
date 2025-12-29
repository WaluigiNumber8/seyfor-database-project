using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.ViewModel.Core;
using SeyforDatabaseProject.ViewModel.Equipment;

namespace SeyforDatabaseProject.ViewModel
{
    public class MainVM : ViewModelBase
    {
        public ViewModelBase CurrentVM { get; }

        public MainVM(Hotel hotel)
        {
            CurrentVM = EquipmentVM.Create(hotel);
        }
    }
}