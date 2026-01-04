using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SeyforDatabaseProject.ViewModel.Equipment;

namespace SeyforDatabaseProject.Views.Equipment
{
    public partial class EquipmentListView : UserControl
    {
        public EquipmentListView()
        {
            InitializeComponent();
        }

        private void EquipmentListView_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (EquipmentItemsListView == null) return;
            CollectionViewSource.GetDefaultView(EquipmentItemsListView.ItemsSource).Filter += FilterEquipment;
        }

        private void FilterBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (EquipmentItemsListView == null) return;
            CollectionViewSource.GetDefaultView(EquipmentItemsListView.ItemsSource).Refresh();
        }
        
        private bool FilterEquipment(object item)
        {
            if (string.IsNullOrEmpty(FilterBox.Text)) return true;

            EquipmentItemVM equipment = (EquipmentItemVM) item;
            
            return (equipment.Title.StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase)
                    || equipment.Description.StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase));
        }
        
    }
}