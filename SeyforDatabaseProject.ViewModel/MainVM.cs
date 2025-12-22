using SeyforDatabaseProject.Model;
using SeyforDatabaseProject.ViewModel.Core;

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