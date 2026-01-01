using System.Windows.Controls;
using System.Windows.Input;

namespace SeyforDatabaseProject.Views.Edit_Screens
{
    public partial class RoomEditView : UserControl
    {
        public RoomEditView()
        {
            InitializeComponent();
        }

        private void RoomNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only decimal
            e.Handled = !int.TryParse(e.Text, out _);
        }

        private void CapacityTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only integer
            e.Handled = !int.TryParse(e.Text, out _);
        }

        private void PricePerNightTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only decimal
            e.Handled = !decimal.TryParse(e.Text, out _);
        }
    }
}