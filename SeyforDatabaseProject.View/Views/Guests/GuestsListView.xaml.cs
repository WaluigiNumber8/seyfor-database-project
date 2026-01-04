using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SeyforDatabaseProject.ViewModel.Guests;

namespace SeyforDatabaseProject.Views.Guests
{
    public partial class GuestsListView : UserControl
    {
        private ICollectionView _defaultView;

        public GuestsListView()
        {
            InitializeComponent();
        }

        private void GuestsListView_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (GuestItemsListView == null) return;
            _defaultView = CollectionViewSource.GetDefaultView(GuestItemsListView.ItemsSource);
            _defaultView.Filter += FilterGuests;
        }
        
        private void GuestsListView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            if (GuestItemsListView == null) return;
            _defaultView.Filter -= FilterGuests;
        }
        
        private void FilterBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (GuestItemsListView == null) return;
            _defaultView.Refresh();
        }
        
        private bool FilterGuests(object item)
        {
            if (string.IsNullOrEmpty(FilterBox.Text)) return true;

            GuestItemVM guest = (GuestItemVM) item;

            return (guest.Name.StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase) ||
                    guest.Surname.StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase) ||
                    guest.Email.StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase) ||
                    guest.PhoneNumber.StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase));
        }

    }
}