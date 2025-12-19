using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel
{
    public class MainVM : ViewModelBase
    {
        public ViewModelBase CurrentVM { get; }

        public MainVM()
        {
            CurrentVM = new EquipmentVM();
        }
    }
}