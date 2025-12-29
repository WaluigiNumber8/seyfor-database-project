using System.Windows.Input;
using SeyforDatabaseProject.ViewModel.Core;

namespace SeyforDatabaseProject.ViewModel.Equipment
{
    public class EquipmentEditVM : ViewModelBase
    {
        #region Properties

        private string _title;
        public string Title
        {
            get => _title;
            set
            {
                _title = value;
                OnPropertyChanged();
            }
        }

        private string _description;
        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged();
            }
        }
        
        #endregion
        
        public ICommand SaveCommand { get; }
        public ICommand CancelCommand { get; }

        public EquipmentEditVM()
        {
            
        }
    }
}