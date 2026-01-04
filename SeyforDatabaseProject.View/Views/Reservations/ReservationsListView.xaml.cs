using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SeyforDatabaseProject.ViewModel.Reservations;

namespace SeyforDatabaseProject.Views.Reservations
{
    public partial class ReservationsListView : UserControl
    {
        private ICollectionView _defaultView;
        
        public ReservationsListView()
        {
            InitializeComponent();
        }

        private void ReservationsListView_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (ReservationItemsListView == null) return;
            _defaultView = CollectionViewSource.GetDefaultView(ReservationItemsListView.ItemsSource);
            _defaultView.Filter += FilterGuests;
        }

        private void ReservationsListView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            if (ReservationItemsListView == null) return;
            _defaultView.Filter -= FilterGuests;
        }

        private void FilterBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (ReservationItemsListView == null) return;
            _defaultView.Refresh();
        }
        
        private bool FilterGuests(object item)
        {
            if (string.IsNullOrEmpty(FilterBox.Text)) return true;

            ReservationItemVM reservation = (ReservationItemVM) item;

            return (reservation.Guest.Name.StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase) ||
                    reservation.Guest.Surname.StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase) ||
                    reservation.DateStart.StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase) ||
                    reservation.DateEnd.StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase) ||
                    reservation.Room.RoomNumber.ToString().StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase) ||
                    reservation.Room.RoomType.ToString().StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase) ||
                    reservation.State.StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase));
        }
    }
}