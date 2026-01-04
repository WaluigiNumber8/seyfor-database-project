using System.Windows.Controls;
using System.Windows.Input;

namespace SeyforDatabaseProject.Views.Guests
{
    public partial class GuestsEditView : UserControl
    {
        public GuestsEditView()
        {
            InitializeComponent();
        }

        private void PhoneNumberTextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            // Allow only decimal
            e.Handled = !int.TryParse(e.Text, out _);
        }
    }
}