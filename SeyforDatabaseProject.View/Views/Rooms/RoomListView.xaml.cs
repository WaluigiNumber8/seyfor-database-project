using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using SeyforDatabaseProject.ViewModel.Rooms;

namespace SeyforDatabaseProject.Views.Rooms
{
    public partial class RoomListView : UserControl
    {
        private ICollectionView _defaultView;
        
        public RoomListView()
        {
            InitializeComponent();
        }

        private void RoomListView_OnLoaded(object sender, RoutedEventArgs e)
        {
            if (RoomItemsListView == null) return;
            _defaultView = CollectionViewSource.GetDefaultView(RoomItemsListView.ItemsSource);
            _defaultView.Filter += FilterGuests;
        }

        private void RoomListView_OnUnloaded(object sender, RoutedEventArgs e)
        {
            if (RoomItemsListView == null) return;
            _defaultView.Filter -= FilterGuests;
        }

        private void FilterBox_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (RoomItemsListView == null) return;
            _defaultView.Refresh();
        }
        
        private bool FilterGuests(object item)
        {
            if (string.IsNullOrEmpty(FilterBox.Text)) return true;

            RoomItemVM room = (RoomItemVM) item;

            return (room.RoomNumber.ToString().StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase) ||
                    room.RoomType.StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase) ||
                    room.AvailabilityStatus.StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase) ||
                    room.Capacity.ToString().StartsWith(FilterBox.Text, StringComparison.OrdinalIgnoreCase));
        }
    }
}